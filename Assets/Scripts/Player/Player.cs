using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool IsHiding { get; private set; }

    [SerializeField] GameObject _hidingScreen;
    [SerializeField] GameObject _dontMoveText;

    public static Player Instance { get; private set; }
    void Awake()
    {
        Instance = this;
        _dontMoveText.SetActive(false);
        _hidingScreen.SetActive(false);
    }

    void Update()
    {
        if (!GameManager.Instance.GameStarted || !IsHiding) return;

        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0 || Input.GetKeyDown(KeyCode.Escape))
        {
            Hide(false);
        }
    }

    public void Hide(bool state)
    {
        IsHiding = state;

        _hidingScreen.SetActive(IsHiding);
        GameManager.Instance.Freeze(IsHiding);

        if (IsHiding && MotherController.Instance.IsInRoom)
        {
            StartCoroutine(HideAnimation());
            IEnumerator HideAnimation()
            {
                _dontMoveText.SetActive(true);
                yield return new WaitForSeconds(2);
                _dontMoveText.SetActive(false);
            }
        }
        else
        {
            _dontMoveText.SetActive(false);
        }
    }
}
