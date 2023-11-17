using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wardrobe : Interactable
{
    protected override void Interact()
    {
        base.Interact();
        PuzzleManager.Instance.LoadPuzzle("Wardrobe");
    }
}
