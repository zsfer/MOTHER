using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueInteractable : PuzzleInteractable
{
    public string[] Lines;
    public UnityEvent OnDialogueComplete;

    protected override void Interact()
    {
        DialogueRunner.Instance.RunDialogue(Lines, () =>
        {
            OnDialogueComplete.Invoke();
        });
    }
}
