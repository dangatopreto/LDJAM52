using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    [HideInInspector]
    public GameGrid selectedItemGrid;

    GridItem selectedItem;

    private void Update()
    {
        if (selectedItemGrid == null) return;

        if (Input.GetMouseButtonDown(0))
        {
            Vector2Int tileGridPos = selectedItemGrid.GetTileGridPosition(Input.mousePosition);

            if (selectedItem == null)
            {
                selectedItem = selectedItemGrid.PickUpItem(tileGridPos.x, tileGridPos.y);
            }
            else
            {
                selectedItemGrid.PlaceItem(selectedItem, tileGridPos.x, tileGridPos.y);
            }
        }
    }
}
