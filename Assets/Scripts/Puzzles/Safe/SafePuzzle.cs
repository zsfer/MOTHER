using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SafePuzzle : PuzzleBehaviour
{
    [SerializeField] GameObject _puzzleUI;
    [SerializeField] GameObject _safeDoor;
    [SerializeField] TextMeshProUGUI _safeScreen;
    [SerializeField] GameObject _windowKey;
    string _code = "";

    private void Start()
    {
        _puzzleUI.SetActive(false);
        _windowKey.SetActive(false);
    }

    public override void OpenPuzzle()
    {
        _puzzleUI.SetActive(true);
        base.OpenPuzzle();
    }

    public override void LeavePuzzle()
    {
        _puzzleUI.SetActive(false);
        base.LeavePuzzle();
    }

    public void AddCode(string val)
    {
        if (_code.Length < 6)
        {
            _code += val;
        }

        VerifyCode();
    }

    void VerifyCode()
    {
        _safeScreen.text = new string('*', _code.Length);
        if (_code.Length < 6) return;

        if (_code.Equals("862154"))
        {
            _windowKey.SetActive(true);
            _safeDoor.SetActive(false);
        }
        else
        {
            // TODO play alarm and alert mother
            // TODO alert mother
            _code = "";
            VerifyCode();
        }
    }

}

