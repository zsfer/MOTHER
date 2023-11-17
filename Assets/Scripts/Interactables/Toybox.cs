using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toybox : Interactable
{

    protected override void Interact()
    {
        if (Inventory.Instance.GetItemByAssetID("ToyboxKey") == null)
        {
            DialogueRunner.Instance.RunDialogue(new string[] { "It's locked" });
            return;
        }

        PuzzleManager.Instance.LoadPuzzle("Toybox");

        base.Interact();
    }
}
