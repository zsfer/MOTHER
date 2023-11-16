using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool CanPlayerMove { get; private set; }

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
}
