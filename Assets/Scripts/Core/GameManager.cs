using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool CanPlayerMove { get; private set; }
    public bool GameStarted { get; set; }

    public GameObject[] DisableOnGameOver;

    #region Singleton
    public static GameManager Instance { get; private set; }
    void Awake()
    {
        Instance = this;
    }
    #endregion

    public void Freeze(bool isFrozen)
    {
        CanPlayerMove = !isFrozen;
    }

    public void GameOver()
    {
        foreach (var item in DisableOnGameOver)
        {
            item.SetActive(false);
        }
    }
}
