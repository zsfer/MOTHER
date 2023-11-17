using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BookshelfPuzzle : PuzzleBehaviour
{
    private string _puzzleOrder = "";
    [SerializeField] GameObject _combinationScreen;
    [SerializeField] GameObject _combinationItem;
    [SerializeField] GameObject _drawerCover;

    [SerializeField] GameObject[] _hidden;
    [SerializeField] AudioClip _errorSFX;

    private void Start()
    {
        foreach (var o in _hidden)
        {
            o.SetActive(false);
        }
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
            foreach (var o in _hidden)
            {
                o.SetActive(true);
            }
            Destroy(_drawerCover);
        }
        else
        {
            _puzzleOrder = "";
            GetComponent<AudioSource>().PlayOneShot(_errorSFX);
            MotherController.Instance.ChangeState(MotherState.GoToRoom);
            foreach (Transform child in _combinationScreen.transform)
            {
                Destroy(child.gameObject);
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

    private void Update()
    {
        print(_combinationScreen.activeSelf);
    }
}
