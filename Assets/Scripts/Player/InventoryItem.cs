using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Inventory Item", menuName = "MOTHER/Inventory Item", order = 0)]
public class InventoryItem : ScriptableObject
{
    public string AssetID;
    public string ItemName;
    [TextArea]
    public string ItemDescription;
    public Sprite InventoryIcon;
    public Sprite InteractImage;

    public InventoryItem AfterInteractItem;
}
