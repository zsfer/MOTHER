using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowLock : PuzzleInteractable<WindowPuzzle>
{
    protected override void Interact()
    {
        if (Inventory.Instance.GetItemByAssetID("WindowKey") != null)
        {
            Inventory.Instance.RemoveItemByAssetID("WindowKey");
            Puzzle.RemoveLock();
            Destroy(gameObject);
        }
        else
        {
            DialogueRunner.Instance.RunDialogue(new string[] { "I need a key for this." });
        }
    }
}
