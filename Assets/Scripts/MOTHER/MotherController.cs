using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherController : MonoBehaviour
{
    [Header("Audio Stuff")]
    [SerializeField] AudioClip _dialogueSFX;
    [SerializeField] AudioClip _doorCloseSFX;

    private SpriteRenderer _renderer;
    private bool _isInRoom;

    private AudioSource _audio;

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
            }, _dialogueSFX);
        }
    }

    void Update()
    {
        if (_isInRoom && !Player.Instance.IsHiding)
        {
            print("GOT YOU!");
        }
    }

    void SetMotherVisible(bool isVisible)
    {
        _isInRoom = isVisible;
        _renderer.enabled = isVisible;
        _audio.PlayOneShot(_doorCloseSFX);
    }
}
