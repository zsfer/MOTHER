using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool CanPlayerMove;

    #region Singleton
    public static GameManager Instance { get; private set; }
    void Awake()
    {
        Instance = this;
    }
    #endregion

    void Update()
    {

    }
}
