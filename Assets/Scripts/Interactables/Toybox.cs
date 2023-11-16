using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toybox : Interactable
{
    private bool _isOpenedBefore;

    protected override void Interact()
    {
        if (Inventory.Instance.GetItemByAssetID("ToyboxKey") == null)
        {
            DialogueRunner.Instance.RunDialogue(new string[] { "It's locked" });
            return;
        }

        _isOpenedBefore = true;
        PuzzleManager.Instance.LoadPuzzle("Toybox");

        base.Interact();
    }
}
