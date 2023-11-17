using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreen : MonoBehaviour
{
    [SerializeField] GameObject _menuUI;

    void Start()
    {
        Invoke(nameof(Win), Random.Range(5, 10));
    }

    void Win()
    {
        _menuUI.SetActive(true);
        StartCoroutine(Quit());
        IEnumerator Quit()
        {
            yield return new WaitForSeconds(2);
            Application.Quit();
        }
    }
}
