using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBox : PuzzleInteractable<MusicBoxPuzzle>
{
    AudioSource _audio;
    [SerializeField] AudioClip _musicBoxTune;
    [SerializeField] GameObject _windowKey;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        _windowKey.SetActive(false);
    }

    protected override void Interact()
    {
        base.Interact();

        if (_audio.isPlaying) return;

        StartCoroutine(PlayMusicBox());
        IEnumerator PlayMusicBox()
        {
            _audio.clip = _musicBoxTune;
            _audio.Play();
            GameManager.Instance.FrozenTime = true;
            yield return new WaitUntil(() => _audio.time >= _musicBoxTune.length);
            DialogueRunner.Instance.RunDialogue(new string[] { "?", "It dropped something" }, () =>
            {
                _windowKey.SetActive(true);
                GameManager.Instance.FrozenTime = false;
            });
        }
    }
}
