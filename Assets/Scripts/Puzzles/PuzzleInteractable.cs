using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleInteractable : MonoBehaviour
{
    public string InteractionName;

    private void OnMouseEnter()
    {
        UIController.Instance.ShowHint(InteractionName);
    }

    private void OnMouseDown()
    {
        Interact();
    }

    private void OnMouseExit()
    {
        UIController.Instance.RemoveHint();
    }

    protected virtual void Interact()
    {

    }
}
