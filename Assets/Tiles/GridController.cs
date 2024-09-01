using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    [SerializeField] public int width, height;
    [SerializeField] private Tile _tilePrefab;
    [SerializeField] private Transform _cam;

    [SerializeField] GameObject[] _tileOptions;

    private GameObject[,] _tiles;

    private void Start()
    {
        Debug.Log(gameObject.GetType().Name);
        _tiles = new GameObject[width, height];
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        for(int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                GameObject selectedTile = _tileOptions[UnityEngine.Random.Range(0, _tileOptions.Length)];
                GameObject spawnedTile = Instantiate(selectedTile, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"{spawnedTile.name} {x} {y}";

                bool isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                spawnedTile.GetComponent<Tile>().Init(x, y, gameObject);

                _tiles[x, y] = spawnedTile; 
            }
        }

        _cam.transform.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 0.5f, -10);
    }


    public GameObject GetTileAtPosition(int x, int y)
    {
        Debug.Log(_tiles[x, y].name);
        return _tiles[x, y];
    }

}
