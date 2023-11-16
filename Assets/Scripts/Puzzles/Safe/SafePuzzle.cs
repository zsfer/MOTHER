using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafePuzzle : PuzzleBehaviour
{
    [SerializeField] GameObject _puzzleUI;

    private void Start()
    {
        _puzzleUI.SetActive(false);
    }

    public override void LeavePuzzle()
    {
        _puzzleUI.SetActive(false);

        base.LeavePuzzle();
    }

    public void OpenSafe()
    {
        _puzzleUI.SetActive(true);
    }

}

