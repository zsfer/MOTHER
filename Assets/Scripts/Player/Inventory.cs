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
        if (!item.AllowDuplicate && Items.Contains(item)) return;

        Items.Add(item);
        InventoryUI.Instance.UpdateUI();
        UIController.Instance.ShowNotification(item.name + " added to inventory");
    }

    public InventoryItem GetItemByAssetID(string assetID)
    {
        return Items.Where(i => i.AssetID.Equals(assetID)).FirstOrDefault();
    }

    public void RemoveItem(InventoryItem item) => Items.Remove(item);
    public void RemoveItemByAssetID(string assetID) => Items.Remove(Items.Where(i => i.AssetID.Equals(assetID)).FirstOrDefault());

    public void UseItem(InventoryItem item)
    {
        if (item.AfterInteractItem != null)
        {
            if (item.RequiredItem != null)
            {
                if (GetItemByAssetID(item.RequiredItem.AssetID) == null)
                {
                    DialogueRunner.Instance.RunDialogue(new string[] { "I need something else for this." });
                    return;
                }
                RemoveItemByAssetID(item.RequiredItem.AssetID);
                RemoveItem(item);
            }
            AddItem(item.AfterInteractItem);
        }

        item.OnInteract?.Invoke();
    }

    void Update()
    {
        if (!GameManager.Instance.GameStarted) return;

        if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.I))
        {
            InventoryUI.Instance.ToggleUI();
        }
    }

}

