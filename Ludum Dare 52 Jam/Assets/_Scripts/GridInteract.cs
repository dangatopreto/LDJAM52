using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(GameGrid))]
public class GridInteract : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private GridController _gridController;
    private GameGrid _gameGrid;

    private void Awake()
    {
        _gridController = FindObjectOfType(typeof(GridController)) as GridController;
        _gameGrid = GetComponent<GameGrid>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _gridController.selectedItemGrid = _gameGrid;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _gridController.selectedItemGrid = null;
    }
}
