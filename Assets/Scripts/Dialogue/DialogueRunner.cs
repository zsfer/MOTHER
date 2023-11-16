using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueRunner : MonoBehaviour
{

    [Header("UI")]
    [SerializeField] TextMeshProUGUI _dialogueText;
    public float TypewriterSpeed;

    public AudioClip DialogueSound { get; set; }

    string[] _lines;
    int _lineIndex;

    Action _onDialogueComplete;
    AudioSource _audio;

    #region Singleton Boilerplate
    public static DialogueRunner Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
        _audio = GetComponent<AudioSource>();
        _dialogueText.text = string.Empty;
        gameObject.SetActive(false);
    }
    #endregion

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (_dialogueText.text == _lines[_lineIndex])
            {
                NextLine();
                return;
            }

            StopAllCoroutines();
            _dialogueText.text = _lines[_lineIndex];
        }
    }

    public void RunDialogue(string[] lines, Action onDialogueComplete = null, AudioClip dialogueSound = null)
    {
        _dialogueText.text = string.Empty;
        if (lines == null || lines.Length == 0)
        {
            onDialogueComplete.Invoke();
            return;
        }

        _lineIndex = 0;
        _lines = lines;
        if (onDialogueComplete != null) _onDialogueComplete = onDialogueComplete;
        if (dialogueSound != null) DialogueSound = dialogueSound;

        gameObject.SetActive(true);
        StartCoroutine(DialogueAnimation());
    }

    IEnumerator DialogueAnimation()
    {
        foreach (char c in _lines[_lineIndex].ToCharArray())
        {
            _dialogueText.text += c;
            if (c != ' ') _audio.PlayOneShot(DialogueSound);
            yield return new WaitForSeconds(TypewriterSpeed);
        }

    }

    public void NextLine()
    {
        if (_lineIndex < _lines.Length - 1)
        {
            _lineIndex++;
            _dialogueText.text = string.Empty;
            StartCoroutine(DialogueAnimation());
        }
        else
        {
            gameObject.SetActive(false);
            _onDialogueComplete?.Invoke();
            _onDialogueComplete = null;
        }
    }
}
