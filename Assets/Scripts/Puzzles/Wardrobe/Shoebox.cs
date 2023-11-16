using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoebox : PuzzleInteractable<WardrobePuzzle>
{
    [SerializeField] InventoryItem _note;

    protected override void Interact()
    {
        if (Puzzle.FoundNote) return;

        DialogueRunner.Instance.RunDialogue(new string[] {
            "I can open this box.",
            "There's a note inside."
        }, () =>
        {
            Inventory.Instance.AddItem(_note);
            Puzzle.FoundNote = true;
        });

    }
}
