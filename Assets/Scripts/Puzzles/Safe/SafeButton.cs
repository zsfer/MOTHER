using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeButton : PuzzleInteractable<SafePuzzle>
{
    protected override void Interact()
    {
        base.Interact();
        Puzzle.AddCode(InteractionName);
    }
}
