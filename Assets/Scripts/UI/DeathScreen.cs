using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    void Start()
    {
        Invoke(nameof(GoMenu), 5);
    }

    void GoMenu()
    {
        SceneManager.LoadScene(0);
    }
}
