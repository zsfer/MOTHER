using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public Puzzle[] Puzzles;
    public bool IsInPuzzle;
    public GameObject[] DisableOnPuzzleLoad;
    [SerializeField] GameObject _puzzleUI;

    public static PuzzleManager Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UnloadPuzzles();
    }

    public TPuzzle GetPuzzle<TPuzzle>() where TPuzzle : PuzzleBehaviour
    {
        foreach (var p in Puzzles)
        {
            if (p.Behaviour is TPuzzle)
                return p.Behaviour as TPuzzle;
        }

        return null;
    }

    public TPuzzle GetActivePuzzle<TPuzzle>() where TPuzzle : PuzzleBehaviour
    {
        foreach (var p in Puzzles)
        {
            if (p.Behaviour.gameObject.activeSelf)
                return p.Behaviour as TPuzzle;
        }

        return null;
    }

    public void LoadPuzzle(string puzzleName)
    {
        foreach (var puzzle in Puzzles)
        {
            puzzle.Behaviour.gameObject.SetActive(puzzle.PuzzleName == puzzleName);
        }

        foreach (var obj in DisableOnPuzzleLoad)
        {
            obj.SetActive(false);
        }

        _puzzleUI.SetActive(true);
        IsInPuzzle = true;
        UIController.Instance.RemoveHint();
        GameManager.Instance.CanPlayerMove = false;
    }

    public void UnloadPuzzles()
    {
        foreach (var puzzle in Puzzles)
        {
            puzzle.Behaviour.gameObject.SetActive(false);
        }

        foreach (var obj in DisableOnPuzzleLoad)
        {
            obj.SetActive(true);
        }

        _puzzleUI.SetActive(false);
        IsInPuzzle = false;
        GameManager.Instance.CanPlayerMove = true;
    }

}
