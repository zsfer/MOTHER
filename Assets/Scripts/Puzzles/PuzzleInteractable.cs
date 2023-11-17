using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PuzzleInteractable<T> : MonoBehaviour where T : PuzzleBehaviour
{
    public string InteractionName;
    public AudioClip InteractAudio;
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
        if (DialogueRunner.Instance.InDialogue) return;
        Interact();
    }

    private void OnMouseExit()
    {
        UIController.Instance.RemoveHint();
    }

    protected virtual void Interact()
    {
        if (InteractAudio != null)
        {
            GetComponent<AudioSource>().PlayOneShot(InteractAudio);
        }
    }
}
