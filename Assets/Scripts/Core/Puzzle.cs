using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Puzzle
{
    public string PuzzleName;
    public PuzzleBehaviour Behaviour;
}

public class PuzzleBehaviour : MonoBehaviour
{
    public void LeavePuzzle()
    {
    }
}
