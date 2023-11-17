using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] GameObject _itemPrefab;
    [SerializeField] Transform _itemGrid;

    [Header("Detailed item panel")]
    [SerializeField] GameObject _detailsUI;
    [SerializeField] TextMeshProUGUI _detailsItemName;
    [SerializeField] TextMeshProUGUI _detailsItemDescription;
    [SerializeField] Image _detailsItemImage;
    [SerializeField] GameObject _detailsInteractButton;

    private bool _isShowing;

    private InventoryItem _selectedItem;

    public static InventoryUI Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    public void ShowUI(bool state)
    {
        if (PuzzleManager.Instance.IsInPuzzle) return;

        _isShowing = state;
        transform.GetChild(0).gameObject.SetActive(_isShowing);
        _detailsUI.SetActive(_isShowing);
        GameManager.Instance.Freeze(_isShowing);

        UpdateUI();
    }

    public void ToggleUI(bool forceOpen = false)
    {
        if (PuzzleManager.Instance.IsInPuzzle && !forceOpen) return;

        _isShowing = !_isShowing;
        transform.GetChild(0).gameObject.SetActive(_isShowing);
        _detailsUI.SetActive(false);
        GameManager.Instance.Freeze(_isShowing);

        UpdateUI();
    }

    public void UpdateUI()
    {
        foreach (Transform child in _itemGrid)
        {
            Destroy(child.gameObject);
        }

        foreach (var item in Inventory.Instance.Items)
        {
            Instantiate(_itemPrefab, _itemGrid).GetComponent<InventoryItemUI>().ItemData = item;
        }
    }

    public void ShowDetail(InventoryItem item)
    {
        _selectedItem = item;
        _detailsUI.SetActive(true);
        _detailsItemName.text = item.ItemName;
        _detailsItemDescription.text = item.ItemDescription;
        _detailsItemImage.sprite = item.InteractImage;

        _detailsInteractButton.SetActive(item.HasInteraction);
    }

    // ONLY HAPPENS ONCE SO NO NEED FOR IT TO BE GENERAL USE RIGHT NEOW
    // will update in the future if need but im out of time.
    public void InteractItem()
    {
        Inventory.Instance.UseItem(_selectedItem);
    }

}
