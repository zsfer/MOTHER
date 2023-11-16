using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookshelfPuzzle : PuzzleBehaviour
{
    private string _puzzleOrder = "";
    [SerializeField] GameObject _combinationScreen;
    [SerializeField] GameObject _combinationItem;
    [SerializeField] GameObject _drawerCover;

    private void Start()
    {
        _combinationScreen.SetActive(false);
    }

    public void AddBook(int orderNumber)
    {
        if (_puzzleOrder.Length < 4)
        {
            Instantiate(_combinationItem, _combinationScreen.transform);
            _puzzleOrder += orderNumber;
        }
        VerifyCombination();
    }

    void VerifyCombination()
    {
        if (_puzzleOrder.Length < 4) return;

        if (_puzzleOrder == "1234")
        {
            Destroy(_drawerCover);
        }
        else
        {
            StartCoroutine(WrongCode());
            IEnumerator WrongCode()
            {
                // play alarm sound
                // alert mother
                yield return new WaitForSeconds(1);
                _puzzleOrder = "";
                foreach (Transform child in _combinationScreen.transform)
                {
                    Destroy(child.gameObject);
                }
            }
        }
    }

    public override void OpenPuzzle()
    {
        _combinationScreen.SetActive(true);
        base.OpenPuzzle();
    }

    public override void LeavePuzzle()
    {
        _combinationScreen.SetActive(false);
        base.LeavePuzzle();
    }
}
