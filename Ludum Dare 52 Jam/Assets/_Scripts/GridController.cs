using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    [HideInInspector]
    public GameGrid selectedItemGrid;

    GridItem selectedItem;
    RectTransform itemRectTransform;

    [SerializeField] private List<ItemData> _items;
    [SerializeField] private GameObject _itemPrefab;
    [SerializeField] private Transform _canvasTransform;

    private void Update()
    {
        ItemIconDrag();

        if (selectedItemGrid == null) return;

        if (Input.GetMouseButtonDown(0))
        {
            LeftClickOnGrid();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateRandomItem();
        }
    }

    private void CreateRandomItem()
    {
        GridItem gridItem = Instantiate(_itemPrefab).GetComponent<GridItem>();
        selectedItem = gridItem;

        itemRectTransform = gridItem.GetComponent<RectTransform>();
        itemRectTransform.SetParent(_canvasTransform);

        int selectedItemId = UnityEngine.Random.Range(0, _items.Count);
        gridItem.SetItem(_items[selectedItemId]);
    }

    private void LeftClickOnGrid()
    {
        Vector2Int tileGridPos = selectedItemGrid.GetTileGridPosition(Input.mousePosition);

        if (selectedItem == null)
        {
            PickUpItem(tileGridPos);
        }
        else
        {
            PlaceItem(tileGridPos);
        }
    }

    private void PlaceItem(Vector2Int tileGridPos)
    {
        selectedItemGrid.PlaceItem(selectedItem, tileGridPos.x, tileGridPos.y);
        selectedItem = null;
    }

    private void PickUpItem(Vector2Int tileGridPos)
    {
        selectedItem = selectedItemGrid.PickUpItem(tileGridPos.x, tileGridPos.y);
        if (selectedItem != null)
        {
            itemRectTransform = selectedItem.GetComponent<RectTransform>();
        }
    }

    private void ItemIconDrag()
    {
        if (selectedItem != null)
        {
            itemRectTransform.position = Input.mousePosition;
        }
    }
}
