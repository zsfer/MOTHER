using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public bool IsInPuzzle;

    public Puzzle[] Puzzles;
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
        GameManager.Instance.Freeze(true);
    }

    private void Update()
    {
        if (IsInPuzzle)
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.S))
            {
                UnloadPuzzles();
            }
        }
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
        if (Puzzles.Where(p => p.PuzzleName == puzzleName).FirstOrDefault() == null) return;

        foreach (var puzzle in Puzzles)
        {
            puzzle.Behaviour.gameObject.SetActive(puzzle.PuzzleName == puzzleName);
            if (puzzle.PuzzleName == puzzleName)
            {
                print("[PUZZLE]: Loading " + puzzleName + "Puzzle");
                puzzle.Behaviour.OpenPuzzle();
            }
        }

        foreach (var obj in DisableOnPuzzleLoad)
        {
            obj.SetActive(false);
        }

        _puzzleUI.SetActive(true);
        IsInPuzzle = true;
        UIController.Instance.RemoveHint();
        GameManager.Instance.Freeze(true);
    }

    public void UnloadPuzzles()
    {
        foreach (var puzzle in Puzzles)
        {
            puzzle.Behaviour.LeavePuzzle();
        }

        foreach (var obj in DisableOnPuzzleLoad)
        {
            obj.SetActive(true);
        }

        _puzzleUI.SetActive(false);
        IsInPuzzle = false;
        GameManager.Instance.Freeze(false);
    }

}
