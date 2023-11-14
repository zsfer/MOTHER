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

    private bool _isShowing;

    public static InventoryUI Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void ToggleUI()
    {
        if (!GameManager.Instance.CanPlayerMove || PuzzleManager.Instance.IsInPuzzle) return;

        _isShowing = !_isShowing;
        gameObject.SetActive(_isShowing);
        _detailsUI.SetActive(false);

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
        _detailsUI.SetActive(true);
        _detailsItemName.text = item.ItemName;
        _detailsItemDescription.text = item.ItemDescription;
        _detailsItemImage.sprite = item.InteractImage;
    }

}
