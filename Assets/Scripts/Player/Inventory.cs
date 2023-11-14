using System.Collections;
using System.Collections.Generic;
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
        UIController.Instance.ShowNotification(item.name + " added to inventory");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.I))
        {
            InventoryUI.Instance.ToggleUI();
        }
    }

}



[CreateAssetMenu(fileName = "Inventory Item", menuName = "MOTHER/Inventory Item", order = 0)]
public class InventoryItem : ScriptableObject
{
    public string ItemName;
    [TextArea]
    public string ItemDescription;
    public Sprite InventoryIcon;
    public Sprite InteractImage;

}