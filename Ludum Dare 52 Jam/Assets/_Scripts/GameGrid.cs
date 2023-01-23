using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGrid : MonoBehaviour
{
    private const float _tileWidth = 64;
    private const float _tileHeight = 64;

    GridItem[,] gridItemSlot;

    private RectTransform _rectTransform;
    [SerializeField] private int _gridSizeWidth = 9;
    [SerializeField] private int _gridSizeHeight = 9;

    private Vector2 _positionOnTheGrid = new Vector2();
    private Vector2Int _tileGridPosition = new Vector2Int();

    [SerializeField] GameObject inventoryItemPrefab;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        Init(_gridSizeWidth, _gridSizeHeight);

        GridItem gridItem = Instantiate(inventoryItemPrefab).GetComponent<GridItem>();
        PlaceItem(gridItem, 5, 4);
    }

    public GridItem PickUpItem(int posX, int posY)
    {
        GridItem itemToReturn = gridItemSlot[posX, posY];
        gridItemSlot[posX, posY] = null;
        return itemToReturn;
    }

    private void Init(int width, int height)
    {
        gridItemSlot = new GridItem[width, height];
        Vector2 size = new Vector2(width * _tileWidth, height * _tileHeight);
        _rectTransform.sizeDelta = size;
    }

    public Vector2Int GetTileGridPosition(Vector2 mousePos)
    {
        _positionOnTheGrid.x = mousePos.x - _rectTransform.position.x;
        _positionOnTheGrid.y = _rectTransform.position.y - mousePos.y;

        _tileGridPosition.x = (int)(_positionOnTheGrid.x / _tileWidth);
        _tileGridPosition.y = (int)(_positionOnTheGrid.y / _tileHeight);

        return _tileGridPosition;
    }

    public void PlaceItem(GridItem gridItem, int posX, int posY)
    {
        RectTransform rectTransform = gridItem.GetComponent<RectTransform>();
        rectTransform.SetParent(this._rectTransform);
        gridItemSlot[posX, posY] = gridItem;

        Vector2 position = new Vector2();
        position.x = posX * _tileWidth + _tileWidth / 2;
        position.y = -(posY * _tileHeight + _tileHeight / 2);

        rectTransform.localPosition = position;

    }
}
