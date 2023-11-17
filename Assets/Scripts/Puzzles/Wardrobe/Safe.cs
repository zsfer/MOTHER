using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safe : PuzzleInteractable<WardrobePuzzle>
{
    private bool _isFirst;

    protected override void Interact()
    {
        if (_isFirst)
        {
            DialogueRunner.Instance.RunDialogue(new string[] { "What's a safe doing here?" }, () =>
            {
                PuzzleManager.Instance.LoadPuzzle("Safe");
                _isFirst = false;
            });
        }
        else
        {
            PuzzleManager.Instance.LoadPuzzle("Safe");
        }
    }
}
