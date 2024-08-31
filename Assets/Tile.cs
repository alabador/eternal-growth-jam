using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color _baseColor, _offsetColor;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight;
    private GameObject _gridController;

    private int _x, _y;

    public void Init(bool isOffset, int x, int y, GameObject gridController)
    {
        _renderer.color = isOffset ? _offsetColor : _baseColor;
        _highlight.SetActive(false);
        _x = x;
        _y = y;
        _gridController = gridController;

    }

    private void OnMouseEnter()
    {
        _highlight.SetActive(true);
    }

    private void OnMouseExit() 
    { 
        _highlight?.SetActive(false);
    }

    private void OnMouseDown()
    {
        // Returns the tile that is being clicked.
        
        // Use this below if accessing the tile in GridController's array is important.
        //_gridController.GetComponent<GridController>().GetTileAtPosition(_x, _y);


        ReturnTile();
    }

    private GameObject ReturnTile()
    {
        // Use this if accessing the tile in GridController's array is not important.
        Debug.Log(gameObject.name);
        return gameObject;
    }
}
