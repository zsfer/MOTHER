using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _hintText;
    [SerializeField] TextMeshProUGUI _notificationText;

    [SerializeField] GameObject _inventoryUIGroup;

    public static UIController Instance { get; private set; }
    void Awake()
    {
        Instance = this;
        _hintText.text = string.Empty;
        _notificationText.text = string.Empty;
    }

    public void ShowHint(string text)
    {
        _hintText.text = text;
    }

    public void RemoveHint()
    {
        _hintText.text = string.Empty;
    }

    public void ShowNotification(string text)
    {
        _notificationText.text = string.Empty;
        StartCoroutine(Notif());

        IEnumerator Notif()
        {
            _notificationText.text = text;
            yield return new WaitForSeconds(2);
            _notificationText.text = string.Empty;
        }
    }

    public void ShowInventory(bool state)
    {
        _inventoryUIGroup.SetActive(state);
    }

}
