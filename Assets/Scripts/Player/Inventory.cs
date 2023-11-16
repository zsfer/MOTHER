using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public static Inventory Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }

    public List<InventoryItem> Items;

    public void AddItem(InventoryItem item)
    {
        if (Items.Contains(item)) return;

        Items.Add(item);
        InventoryUI.Instance.UpdateUI();
        UIController.Instance.ShowNotification(item.name + " added to inventory");
    }

    public InventoryItem GetItemByAssetID(string assetID)
    {
        return Items.Where(i => i.AssetID.Equals(assetID)).FirstOrDefault();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.I))
        {
            InventoryUI.Instance.ToggleUI();
        }
    }

}

