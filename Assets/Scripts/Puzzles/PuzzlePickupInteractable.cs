using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuzzlePickupInteractable : PuzzleInteractable<PuzzleBehaviour>
{
    public bool DestroyOnPickup;
    public InventoryItem ItemToPickup;
    public string[] PickupDialogue;

    public UnityEvent OnPickup;

    protected override void Interact()
    {
        DialogueRunner.Instance.RunDialogue(PickupDialogue, () =>
        {
            Inventory.Instance.AddItem(ItemToPickup);
            OnPickup.Invoke();

            if (DestroyOnPickup)
                Destroy(gameObject);
            else
                enabled = false;
        });
    }
}
