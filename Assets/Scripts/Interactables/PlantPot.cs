using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantPot : Interactable
{
    [SerializeField] InventoryItem _poemItem;

    protected override void Interact()
    {
        DialogueRunner.Instance.RunDialogue(new string[] {
            "?",
            "There's a piece of crumpled paper here."
        }, onDialogueComplete: () =>
        {
            Inventory.Instance.AddItem(_poemItem);
        });
        base.Interact();
    }
}
