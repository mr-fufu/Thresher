using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManagementScript : MonoBehaviour
{
    public GameObject tilesGrid;
    public GameObject effectsGrid;
    public GameObject objectsGrid;

    private Tilemap tiles;
    private Tilemap effects;
    private Tilemap objects;

    public Tile pointerTile;

    public GameObject summonLibrary;

    public int mapSizeX;
    public int mapSizeY;

    public string checkTileType;

    public int[] pointerLocation;
    public int[] mapSize;

    public int checkMatrix1;
    public int checkMatrix2;

    // Start is called before the first frame update
    void Start()
    {
        tiles = tilesGrid.GetComponent<Tilemap>();
        effects = effectsGrid.GetComponent<Tilemap>();
        objects = objectsGrid.GetComponent<Tilemap>();

        pointerLocation = new int[2] { 0, 15 };
        mapSize = new int[2] { mapSizeX, mapSizeY };

        showPointer();

        /*
        for (int axis1 = 0; axis1 <= mapSizeX; axis1++)
        {
            for (int axis2 = 0; axis2 <= mapSizeX; axis2++)
            {
                checkTileType = checkTile(axis1, axis2);
            }
        }
        */
    }

    string checkTile(int[] typeCheckLocation)
    {
        return (tiles.GetInstantiatedObject(new Vector3Int(typeCheckLocation[0], typeCheckLocation[1], 0)).GetComponent<tileObjectScript>().tileType);
    }

    int checkTileHeight(int[] heightCheckLocation)
    {
        return Mathf.FloorToInt(tiles.GetCellCenterLocal(new Vector3Int(heightCheckLocation[0], heightCheckLocation[1], 0)).y);
    }

    void changeTile(int[] changeLocation, Tile changeToTile)
    {
        tiles.SetTile(new Vector3Int(changeLocation[0],changeLocation[1], 0), changeToTile);
    }

    void showPointer()
    {
        effects.ClearAllTiles();

        effects.SetTile(new Vector3Int(pointerLocation[0], pointerLocation[1], 0), pointerTile);
        effects.SetTransformMatrix(new Vector3Int(pointerLocation[0], pointerLocation[1], 0), 
            tiles.GetTransformMatrix(new Vector3Int(pointerLocation[0], pointerLocation[1], 0)));

        Debug.Log(checkTileHeight(pointerLocation));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (pointerLocation[0] < mapSize[0])
            {
                pointerLocation[0]++;
                showPointer();
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (pointerLocation[0] > 0)
            {
                pointerLocation[0]--;
                showPointer();
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (pointerLocation[1] < mapSize[1])
            {
                pointerLocation[1]++;
                showPointer();
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (pointerLocation[1] > 0)
            {
                pointerLocation[1]--;
                showPointer();
            }
        }

    }
}
