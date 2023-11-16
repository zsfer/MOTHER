using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleInteractable<T> : MonoBehaviour where T : PuzzleBehaviour
{
    public string InteractionName;
    protected T Puzzle { get; private set; }

    private void Start()
    {
        Puzzle = PuzzleManager.Instance.GetPuzzle<T>();
    }

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
