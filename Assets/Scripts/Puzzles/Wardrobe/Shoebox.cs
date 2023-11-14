using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoebox : PuzzleInteractable
{
    [SerializeField] InventoryItem _note;

    protected override void Interact()
    {
        var puzzle = PuzzleManager.Instance.GetActivePuzzle<WardrobePuzzle>();
        if (puzzle.FoundNote) return;

        DialogueRunner.Instance.RunDialogue(new string[] {
            "I can open this box.",
            "There's a note inside."
        }, () =>
        {
            Inventory.Instance.AddItem(_note);
            puzzle.FoundNote = true;
        });

    }
}
