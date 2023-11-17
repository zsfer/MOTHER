using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class MotherController : MonoBehaviour
{
    [Header("Audio Stuff")]
    [SerializeField] AudioClip _dialogueSFX;
    [SerializeField] AudioClip _doorCloseSFX;

    private SpriteRenderer _renderer;
    public bool IsInRoom { get; private set; }

    private AudioSource _audio;

    public static MotherController Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _audio = GetComponent<AudioSource>();

        StartCoroutine(IntroCutscene());
        IEnumerator IntroCutscene()
        {
            GameManager.Instance.Freeze(true);
            yield return new WaitForSeconds(1);
            DialogueRunner.Instance.RunDialogue(new string[] { "Goodnight my love. You should head to bed now.", "I'll be checking on you frequently.", "Sleep tight." }, () =>
            {
                GameManager.Instance.Freeze(false);
                SetMotherVisible(false);
                GameManager.Instance.GameStarted = true;
            }, _dialogueSFX);
        }
    }

    void Update()
    {
        if (IsInRoom && !Player.Instance.IsHiding)
        {
            print("GOT YOU!");
        }
    }

    void SetMotherVisible(bool isVisible)
    {
        IsInRoom = isVisible;
        _renderer.enabled = isVisible;
        _audio.PlayOneShot(_doorCloseSFX);
    }
}
