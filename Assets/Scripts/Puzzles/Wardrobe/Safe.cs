using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safe : PuzzleInteractable
{
    private bool _isFirst;

    protected override void Interact()
    {
        if (_isFirst)
        {
            DialogueRunner.Instance.RunDialogue(new string[] { "What's a safe doing here?" }, () =>
            {
                PuzzleManager.Instance.GetPuzzle<SafePuzzle>().OpenSafe();
                _isFirst = false;
            });
        }
    }
}
