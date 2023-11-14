using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clothes : PuzzleInteractable
{
    protected override void Interact()
    {
        DialogueRunner.Instance.RunDialogue(new string[] {
            "I think i can move these clothes"
        }, () =>
        {
            Destroy(gameObject);
        });
    }

}
