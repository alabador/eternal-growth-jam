using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GridController : MonoBehaviour
{
    [SerializeField] public int width, height;
    [SerializeField] private Tile _tilePrefab;
    [SerializeField] private Transform _cam;

    private Tile[,] _tiles;

    private void Start()
    {
        _tiles = new Tile[width, height];
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        Debug.Log(width);
        Debug.Log(height);
        for(int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Tile spawnedTile = Instantiate(_tilePrefab, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";

                bool isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                spawnedTile.Init(isOffset);

                _tiles[x, y] = spawnedTile; 
            }
        }

        _cam.transform.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 0.5f, -10);
    }


    public Tile GetTileAtPosition(int x, int y)
    {
        Debug.Log(_tiles[x, y].name);
        return _tiles[x, y];
    }

}
