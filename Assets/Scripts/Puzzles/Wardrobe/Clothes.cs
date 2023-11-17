using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clothes : PuzzleInteractable<WardrobePuzzle>
{
    [SerializeField] GameObject _safe;


    private void Start()
    {
        _safe.SetActive(false);
    }

    protected override void Interact()
    {
        DialogueRunner.Instance.RunDialogue(new string[] {
            "I think i can move these clothes"
        }, () =>
        {
            _safe.SetActive(true);
            Destroy(gameObject);
        });
    }

}
