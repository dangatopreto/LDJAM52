using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridItem : MonoBehaviour
{
    public ItemData itemData;

    public int onGridPositionX;
    public int onGridPositionY;

    public void SetItem(ItemData itemData)
    {
        this.itemData = itemData;

        GetComponent<Image>().sprite = itemData.itemIcon;

        Vector2 size = new Vector2();
        size.x = itemData.width * GameGrid.tileWidth;
        size.y = itemData.height * GameGrid.tileHeight;
        GetComponent<RectTransform>().sizeDelta = size;
    }
}
