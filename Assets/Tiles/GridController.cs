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
    private bool tutorialLevel;

    //private void Start()
    //{
    //    tutorialLevel = true;
    //    // Tutorial Level
    //    if (tutorialLevel)
    //    {
    //        width = 3; height = 3;
    //        _tiles = new GameObject[width, height];
    //        StartTutorialLevel();

    //    }
    //}

    public void Init(int gridWidth, int gridHeight)
    {
        _tiles = new GameObject[width, height];
        GenerateGrid();
    }

    public void StartTutorialLevel()
    {
        width = 3; height = 3;
        _tiles = new GameObject[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                GameObject selectedTile = _tileOptions[0]; // Spawn Desert Tile
                //if (x == 1 && y == 1)
                //{
                //    selectedTile = _tileOptions[1]; // Spawn Grass Tile

                //}
                GameObject spawnedTile = Instantiate(selectedTile, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"{spawnedTile.name} {x} {y}";

                spawnedTile.GetComponent<Tile>().Init(x, y, gameObject);

                _tiles[x, y] = spawnedTile;
            }
        }

        _cam.transform.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 0.5f, -10);
    }

    public void TransformMiddle()
    {
        GameObject selectedTile = _tileOptions[1];
        GameObject spawnedTile = Instantiate(selectedTile, new Vector3(1, 1), Quaternion.identity);

        // Destroy old object
        GameObject old = GameObject.Find("Desert 1 1");
        Destroy(old);
        
        spawnedTile.name = $"{spawnedTile.name} {1} {1}";
        spawnedTile.GetComponent<Tile>().Init(1, 1, gameObject);

        _tiles[1, 1] = spawnedTile;
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
