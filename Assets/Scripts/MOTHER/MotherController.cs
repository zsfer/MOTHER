using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum MotherState
{
    Patrol,
    GoToRoom,
    EnterRoom,
    Investigate,
    Attack,
}

public class MotherController : MonoBehaviour
{

    [Header("Behaviour")]
    public float PatrolDuration = 60 * 3;
    public float InvestigateDuration = 5;
    public float MoveSpeed = 2;
    [SerializeField] GameObject _jumpscare;
    float _timer = 0;

    [SerializeField] Renderer[] _renderers;

    MotherState _state;

    [Header("Audio Stuff")]
    [SerializeField] AudioClip _dialogueSFX;
    [SerializeField] AudioClip _doorCloseSFX;
    [SerializeField] AudioClip _footstepsSFX;
    [SerializeField] AudioClip _attackSFX;
    [SerializeField] AudioClip _jumpscareSFX;

    public bool IsInRoom { get; private set; }

    private AudioSource _audio;

    public static MotherController Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        _audio = GetComponent<AudioSource>();

        StartCoroutine(IntroCutscene());
        IEnumerator IntroCutscene()
        {
            GameManager.Instance.Freeze(true);
            yield return new WaitForSeconds(1);
            DialogueRunner.Instance.RunDialogue(new string[] {
                "Goodnight my love. You should head to bed now.",
                "I'll be checking on you frequently.",
                "Sleep tight."
            }, () =>
            {
                GameManager.Instance.Freeze(false);
                SetMotherVisible(false);
                GameManager.Instance.GameStarted = true;

                _state = MotherState.Patrol;
            }, _dialogueSFX);
        }
    }

    void Update()
    {
        if (!GameManager.Instance.GameStarted || GameManager.Instance.FrozenTime) return;

        print(_timer);

        GetComponent<BoxCollider2D>().enabled = _state == MotherState.Attack;

        if (_state == MotherState.Patrol)
        {
            if (_timer <= PatrolDuration)
            {
                _timer += Time.deltaTime;
            }
            else
            {
                _state = MotherState.GoToRoom;
                PlayAudio(_footstepsSFX);
                _timer = 0;
            }
        }

        if (_state == MotherState.GoToRoom)
        {
            _timer += Time.deltaTime;
            if (_timer > 3)
            {
                _state = MotherState.EnterRoom;
            }
        }

        if (_state == MotherState.EnterRoom)
        {
            Player.Instance.PlayHideAnimation();
            SetMotherVisible(true);
            _state = MotherState.Investigate;
            _timer = 0;
        }

        if (_state == MotherState.Investigate)
        {
            if (IsInRoom && !Player.Instance.IsHiding)
            {
                _state = MotherState.Attack;
                _timer = 0;
                PlayAudio(_attackSFX);
            }
            else
            {
                _timer += Time.deltaTime;
                if (_timer >= InvestigateDuration)
                {
                    SetMotherVisible(false);
                    _timer = 0;
                    _state = MotherState.Patrol;
                }
            }
        }

        if (_state == MotherState.Attack)
        {
            InventoryUI.Instance.ShowUI(false);
            GameManager.Instance.Freeze(true);
            _timer += Time.deltaTime;

            if (_timer >= Random.Range(3, 5))
            {
                transform.Translate(MoveSpeed * Time.deltaTime * (Player.Instance.gameObject.transform.position - transform.position));
            }
        }
    }

    void SetMotherVisible(bool isVisible)
    {
        IsInRoom = isVisible;
        foreach (var r in _renderers)
        {
            r.enabled = isVisible;
        }
        PlayAudio(_doorCloseSFX);
    }

    public void ChangeState(MotherState state)
    {
        _state = state;
        _timer = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _jumpscare.SetActive(true);
            PlayAudio(_jumpscareSFX);

            StartCoroutine(Exit());
            IEnumerator Exit()
            {
                yield return new WaitForSeconds(4);
                SceneManager.LoadScene(2);
            }
        }
    }

    void PlayAudio(AudioClip clip, bool canStop = true)
    {
        if (canStop)
            _audio.Stop();
        _audio.clip = clip;
        _audio.Play();
    }
}
