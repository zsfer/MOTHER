using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowPuzzle : PuzzleBehaviour
{

    public int LocksRemoved { get; set; }
    private bool _firstLoad;

    [SerializeField] GameObject _endScreen;

    public override void OpenPuzzle()
    {
        base.OpenPuzzle();

        if (!_firstLoad)
        {
            DialogueRunner.Instance.RunDialogue(new string[] {
                "It's boarded up",
                "I need to get out of here soon.",
                });
            _firstLoad = true;
        }
    }

    public void RemoveLock()
    {
        LocksRemoved++;

        if (LocksRemoved == 3)
        {
            // TODO game over
            _endScreen.SetActive(true);
        }
    }
}
