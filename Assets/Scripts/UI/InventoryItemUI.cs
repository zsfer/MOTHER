using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemUI : MonoBehaviour
{
    public InventoryItem ItemData;

    void Start()
    {
        transform.GetChild(0).GetComponent<Image>().sprite = ItemData.InventoryIcon;
        transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = ItemData.ItemName;
    }

    public void ShowDetail()
    {
        InventoryUI.Instance.ShowDetail(ItemData);
    }

}
