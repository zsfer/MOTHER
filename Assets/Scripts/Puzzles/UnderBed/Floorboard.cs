using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floorboard : PuzzleInteractable<UnderBedPuzzle>
{
    protected override void Interact()
    {
        base.Interact();

        DialogueRunner.Instance.RunDialogue(new string[] { "Looks like I could pry this open." }, () =>
        {
            Destroy(gameObject);
        });
    }
}
