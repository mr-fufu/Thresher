﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManagementScript : MonoBehaviour
{
    public GameObject tilesGrid;
    public GameObject effectsGrid;
    public GameObject objectsGrid;
    public GameObject dataGrid;

    private Tilemap tiles;
    private Tilemap effects;
    private Tilemap objects;
    private Tilemap data;

    public Tile pointerTile;

    public GameObject summonLibrary;

    public TileLibraryScript tileLibrary;

    public int mapSizeX;
    public int mapSizeY;

    public string tileType;

    public int[] pointerLocation;
    public int[] mapSize;
    public int[] endLocation;
    public int[] initLocation;

    private bool initializeCheck;

    // Start is called before the first frame update
    void Start()
    {
        tiles = tilesGrid.GetComponent<Tilemap>();
        effects = effectsGrid.GetComponent<Tilemap>();
        objects = objectsGrid.GetComponent<Tilemap>();
        data = dataGrid.GetComponent<Tilemap>();

        pointerLocation = new int[2] { 0, 15 };
        mapSize = new int[2] { mapSizeX, mapSizeY };

        initializeCheck = false;
    }

    void initialize()
    {
        for (int initAx1 = 0; initAx1 <= mapSizeX; initAx1++)
        {
            for (int initAx2 = 0; initAx2 <= mapSizeX; initAx2++)
            {
                initLocation = new int[2] { initAx1, initAx2 };

                if (tiles.GetTile(new Vector3Int(initLocation[0], initLocation[1], 0)) == tileLibrary.grass_tile)
                {
                    data.GetInstantiatedObject(new Vector3Int(initLocation[0], initLocation[1], 0)).GetComponent<tileObjectScript>().tileType = "grass";
                }
                else if (tiles.GetTile(new Vector3Int(initLocation[0], initLocation[1], 0)) == tileLibrary.water_tile)
                {
                    data.GetInstantiatedObject(new Vector3Int(initLocation[0], initLocation[1], 0)).GetComponent<tileObjectScript>().tileType = "water";
                }
                else if (tiles.GetTile(new Vector3Int(initLocation[0], initLocation[1], 0)) == tileLibrary.sand_tile)
                {
                    data.GetInstantiatedObject(new Vector3Int(initLocation[0], initLocation[1], 0)).GetComponent<tileObjectScript>().tileType = "sand";
                }

                data.GetInstantiatedObject(new Vector3Int(initLocation[0], initLocation[1], 0)).GetComponent<tileObjectScript>().height =
                    Mathf.FloorToInt(checkTileHeight(initLocation));
            }
        }

        showPointer();
    }

    string checkTileType(int[] typeCheckLocation)
    {
        if (data.GetInstantiatedObject(new Vector3Int(typeCheckLocation[0], typeCheckLocation[1], 0)) != null)
        {
            return (data.GetInstantiatedObject(new Vector3Int(typeCheckLocation[0], typeCheckLocation[1], 0)).GetComponent<tileObjectScript>().tileType);
        }
        else
        {
            return ("null");
        }
    }

    void setTileType(int[] typeSetLocation, string setType)
    {
        data.GetInstantiatedObject(new Vector3Int(typeSetLocation[0], typeSetLocation[1], 0)).GetComponent<tileObjectScript>().tileType = setType;
    }

    float checkTileHeight(int[] heightCheckLocation)
    {
        return tiles.GetTransformMatrix(new Vector3Int(heightCheckLocation[0], heightCheckLocation[1], 0))[1,3];
    }

    void changeTile(int[] changeLocation, Tile changeToTile)
    {
        tiles.SetTile(new Vector3Int(changeLocation[0],changeLocation[1], 0), changeToTile);
    }

    void showPointer()
    {
        effects.ClearAllTiles();

        effects.SetTile(new Vector3Int(pointerLocation[0], pointerLocation[1], 1), pointerTile);
        effects.SetTransformMatrix(new Vector3Int(pointerLocation[0], pointerLocation[1], 1), 
            tiles.GetTransformMatrix(new Vector3Int(pointerLocation[0], pointerLocation[1], 0)));

        //Debug.Log(data.GetInstantiatedObject(new Vector3Int(pointerLocation[0], pointerLocation[1], 0)).GetComponent<tileObjectScript>().tileType);
        //Debug.Log(data.GetInstantiatedObject(new Vector3Int(pointerLocation[0], pointerLocation[1], 0)).GetComponent<tileObjectScript>().height);
    }

    void plantPumpkins(int[] pumpkinLocation)
    {
        if (checkTileType(pumpkinLocation) == "grass")
        {
            changeTile(pumpkinLocation, tileLibrary.wheat[0]);
            setTileType(pumpkinLocation, tileLibrary.wheatType[0]);
        }
    }

    void plantWheat(int[] wheatLocation)
    {
        if (checkTileType(wheatLocation) == "grass")
        {
            changeTile(wheatLocation, tileLibrary.pumpkin[0]);
            setTileType(wheatLocation, tileLibrary.pumpkinType[0]); 
        }
    }

    void endTurn()
    {
        for (int axis1 = 0; axis1 <= mapSizeX; axis1++)
        {
            for (int axis2 = 0; axis2 <= mapSizeX; axis2++)
            {
                endLocation = new int[2] { axis1, axis2 };
                tileType = checkTileType(endLocation);

                if (tileType == tileLibrary.wheatType[0])
                {
                    changeTile(endLocation, tileLibrary.wheat[1]);
                    setTileType(endLocation, tileLibrary.wheatType[1]);
                }
                else if (tileType == tileLibrary.wheatType[1])
                {
                    changeTile(endLocation, tileLibrary.wheat[2]);
                    setTileType(endLocation, tileLibrary.wheatType[2]);
                }
                else if (tileType == tileLibrary.pumpkinType[0])
                {
                    changeTile(endLocation, tileLibrary.pumpkin[1]);
                    setTileType(endLocation, tileLibrary.pumpkinType[1]);
                }
                else if (tileType == tileLibrary.pumpkinType[1])
                {
                    changeTile(endLocation, tileLibrary.pumpkin[2]);
                    setTileType(endLocation, tileLibrary.pumpkinType[2]);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!initializeCheck)
        {
            initialize();
            initializeCheck = true;
        }

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
