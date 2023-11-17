using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[CreateAssetMenu(fileName = "Inventory Item", menuName = "MOTHER/Inventory Item", order = 0)]
public class InventoryItem : ScriptableObject
{
    [Header("General")]
    public string AssetID;
    public bool AllowDuplicate;
    public string ItemName;
    [TextArea]
    public string ItemDescription;
    public Sprite InventoryIcon;
    public Sprite InteractImage;

    [Header("Interaction")]
    public bool HasInteraction;
    public InventoryItem RequiredItem;
    public InventoryItem AfterInteractItem;

    public UnityEvent OnInteract;

    public void LoadPuzzle(string puzzleName)
    {
        PuzzleManager.Instance.LoadPuzzle(puzzleName);
        InventoryUI.Instance.ToggleUI(forceOpen: true);
    }
}
