using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGrid : MonoBehaviour
{
    public const float tileWidth = 64;
    public const float tileHeight = 64;

    GridItem[,] gridItemSlot;

    private RectTransform _rectTransform;
    [SerializeField] private int _gridSizeWidth = 9;
    [SerializeField] private int _gridSizeHeight = 9;

    private Vector2 _positionOnTheGrid = new Vector2();
    private Vector2Int _tileGridPosition = new Vector2Int();

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        Init(_gridSizeWidth, _gridSizeHeight);
    }

    public GridItem PickUpItem(int posX, int posY)
    {
        GridItem itemToReturn = gridItemSlot[posX, posY];

        if (itemToReturn == null) { return null; }

        for (int x = 0; x < itemToReturn.itemData.width; x++)
        {
            for (int y = 0; y < itemToReturn.itemData.height; y++)
            {
                gridItemSlot[itemToReturn.onGridPositionX + x, itemToReturn.onGridPositionY + y] = null;
            }
        }

        return itemToReturn;
    }

    private void Init(int width, int height)
    {
        gridItemSlot = new GridItem[width, height];
        Vector2 size = new Vector2(width * tileWidth, height * tileHeight);
        _rectTransform.sizeDelta = size;
    }

    public Vector2Int GetTileGridPosition(Vector2 mousePos)
    {
        _positionOnTheGrid.x = mousePos.x - _rectTransform.position.x;
        _positionOnTheGrid.y = _rectTransform.position.y - mousePos.y;

        _tileGridPosition.x = (int)(_positionOnTheGrid.x / tileWidth);
        _tileGridPosition.y = (int)(_positionOnTheGrid.y / tileHeight);

        return _tileGridPosition;
    }

    public void PlaceItem(GridItem gridItem, int posX, int posY)
    {
        RectTransform rectTransform = gridItem.GetComponent<RectTransform>();
        rectTransform.SetParent(this._rectTransform);

        for (int x = 0; x < gridItem.itemData.width; x++)
        {
            for (int y = 0; y < gridItem.itemData.height; y++)
            {
                gridItemSlot[posX + x, posY + y] = gridItem;
            }
        }

        gridItem.onGridPositionX = posX;
        gridItem.onGridPositionY = posY;

        Vector2 position = new Vector2();
        position.x = posX * tileWidth + tileWidth * gridItem.itemData.width / 2;
        position.y = -(posY * tileHeight + tileHeight * gridItem.itemData.height / 2);

        rectTransform.localPosition = position;

    }
}
