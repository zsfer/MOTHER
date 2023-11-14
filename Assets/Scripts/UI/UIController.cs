using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _hintText;

    public static UIController Instance { get; private set; }
    void Awake()
    {
        Instance = this;
        _hintText.text = string.Empty;
    }

    public void ShowHint(string text)
    {
        _hintText.text = text;
    }

    public void RemoveHint()
    {
        _hintText.text = string.Empty;
    }

}
