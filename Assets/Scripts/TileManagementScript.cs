using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManagementScript : MonoBehaviour
{
    public GameObject tilesGrid;
    public GameObject effectsGrid;
    public GameObject charactersGrid;
    public GameObject dataGrid;
    public GameObject heightGrid;
    public GameObject overlayGrid;

    public GameObject raisedGrid0;
    public GameObject raisedGrid1;
    public GameObject raisedGrid2;
    public GameObject raisedGrid3;
    public GameObject raisedGrid4;
    public GameObject raisedGrid5;
    public GameObject raisedGrid6;

    private Tilemap tiles;
    private Tilemap effects;
    private Tilemap characters;
    private Tilemap data;
    private Tilemap height;
    private Tilemap overlay;

    private Tilemap raised0;
    private Tilemap raised1;
    private Tilemap raised2;
    private Tilemap raised3;
    private Tilemap raised4;
    private Tilemap raised5;
    private Tilemap raised6;

    public Tile pointerTile;

    public GameObject summonLibrary;
    public CameraController mainCamera;
    public TileLibraryScript tileLibrary;

    public int mapSizeX;
    public int mapSizeY;

    [System.NonSerialized]
    public string tileType;

    [System.NonSerialized]
    public int[] pointerLocation;
    [System.NonSerialized]
    public int[] mapSize;
    [System.NonSerialized]
    public int[] endLocation;
    [System.NonSerialized]
    public int[] initLocation;

    [System.NonSerialized]
    public bool debugMode;

    private bool initializeCheck;

    private Matrix4x4 transformHold;

    void Start()
    {
        tiles = tilesGrid.GetComponent<Tilemap>();
        effects = effectsGrid.GetComponent<Tilemap>();
        characters = charactersGrid.GetComponent<Tilemap>();
        data = dataGrid.GetComponent<Tilemap>();
        height = heightGrid.GetComponent<Tilemap>();
        overlay = overlayGrid.GetComponent<Tilemap>();

        raised0 = raisedGrid0.GetComponent<Tilemap>();
        raised1 = raisedGrid1.GetComponent<Tilemap>();
        raised2 = raisedGrid2.GetComponent<Tilemap>();
        raised3 = raisedGrid3.GetComponent<Tilemap>();
        raised4 = raisedGrid4.GetComponent<Tilemap>();
        raised5 = raisedGrid5.GetComponent<Tilemap>();
        raised6 = raisedGrid6.GetComponent<Tilemap>();

        pointerLocation = new int[2] { 0, 15 };
        mapSize = new int[2] { mapSizeX, mapSizeY };

        initializeCheck = false;
    }

    void initialize()
    {
        raised0.ClearAllTiles();
        raised1.ClearAllTiles();
        raised2.ClearAllTiles();
        raised3.ClearAllTiles();
        raised4.ClearAllTiles();
        raised5.ClearAllTiles();
        raised6.ClearAllTiles();

        for (int initAx1 = 0; initAx1 <= mapSizeX; initAx1++)
        {
            for (int initAx2 = 0; initAx2 <= mapSizeX; initAx2++)
            {
                initLocation = new int[2] { initAx1, initAx2 };

                if (Mathf.FloorToInt(checkTileHeight(initLocation)) == 0
                    || Mathf.FloorToInt(checkTileHeight(initLocation)) == 10
                    || Mathf.FloorToInt(checkTileHeight(initLocation)) == 20
                    || Mathf.FloorToInt(checkTileHeight(initLocation)) == 30
                    || Mathf.FloorToInt(checkTileHeight(initLocation)) == 40
                    || Mathf.FloorToInt(checkTileHeight(initLocation)) == 50
                    || Mathf.FloorToInt(checkTileHeight(initLocation)) == 60)
                {
                    data.GetInstantiatedObject(new Vector3Int(initLocation[0], initLocation[1], 0)).GetComponent<tileObjectScript>().height =
                    Mathf.FloorToInt(checkTileHeight(initLocation)) / 10;
                }
                else
                {
                    Debug.Log("Invalid Height @");
                    Debug.Log(initLocation[0]);
                    Debug.Log(initLocation[1]);
                }

                if (tiles.GetTile(new Vector3Int(initLocation[0], initLocation[1], 0)) == tileLibrary.grass_tile_H3)
                {
                    data.GetInstantiatedObject(new Vector3Int(initLocation[0], initLocation[1], 0)).GetComponent<tileObjectScript>().tileType = "grass";
                    changeTile(initLocation, "grass", tileLibrary.grass[0], tileLibrary.grass[1]);
                }
                else if (tiles.GetTile(new Vector3Int(initLocation[0], initLocation[1], 0)) == tileLibrary.water_tile_H3)
                {
                    data.GetInstantiatedObject(new Vector3Int(initLocation[0], initLocation[1], 0)).GetComponent<tileObjectScript>().tileType = "water";
                }
                else if (tiles.GetTile(new Vector3Int(initLocation[0], initLocation[1], 0)) == tileLibrary.sand_tile_H3)
                {
                    data.GetInstantiatedObject(new Vector3Int(initLocation[0], initLocation[1], 0)).GetComponent<tileObjectScript>().tileType = "sand";
                    changeTile(initLocation, "sand", tileLibrary.sand, tileLibrary.sand);
                }
                //else if (tiles.GetTile(new Vector3Int(initLocation[0], initLocation[1], 0)) == tileLibrary.wheat_1_H3)
                //{
                //    data.GetInstantiatedObject(new Vector3Int(initLocation[0], initLocation[1], 0)).GetComponent<tileObjectScript>().tileType = "wheat_1";
                //}
                //else if (tiles.GetTile(new Vector3Int(initLocation[0], initLocation[1], 0)) == tileLibrary.wheat_2_H3)
                //{
                //    data.GetInstantiatedObject(new Vector3Int(initLocation[0], initLocation[1], 0)).GetComponent<tileObjectScript>().tileType = "wheat_2";
                //}
                //else if (tiles.GetTile(new Vector3Int(initLocation[0], initLocation[1], 0)) == tileLibrary.wheat_3_H3)
                //{
                //    data.GetInstantiatedObject(new Vector3Int(initLocation[0], initLocation[1], 0)).GetComponent<tileObjectScript>().tileType = "wheat_3";
                //}
                //else if (tiles.GetTile(new Vector3Int(initLocation[0], initLocation[1], 0)) == tileLibrary.pumpkin_1_H3)
                //{
                //    data.GetInstantiatedObject(new Vector3Int(initLocation[0], initLocation[1], 0)).GetComponent<tileObjectScript>().tileType = "pumpkin_1";
                //}
                //else if (tiles.GetTile(new Vector3Int(initLocation[0], initLocation[1], 0)) == tileLibrary.pumpkin_2_H3)
                //{
                //    data.GetInstantiatedObject(new Vector3Int(initLocation[0], initLocation[1], 0)).GetComponent<tileObjectScript>().tileType = "pumpkin_2";
                //}
                //else if (tiles.GetTile(new Vector3Int(initLocation[0], initLocation[1], 0)) == tileLibrary.pumpkin_3_H3)
                //{
                //    data.GetInstantiatedObject(new Vector3Int(initLocation[0], initLocation[1], 0)).GetComponent<tileObjectScript>().tileType = "pumpkin_3";
                //}
                //else if (tiles.GetTile(new Vector3Int(initLocation[0], initLocation[1], 0)) == tileLibrary.candy_H3)
                //{
                //    data.GetInstantiatedObject(new Vector3Int(initLocation[0], initLocation[1], 0)).GetComponent<tileObjectScript>().tileType = "candy";
                //}
            }
        }

        showPointer();
    }

    public void populateOverlays()
    {
        for (int overAx1 = 0; overAx1 <= mapSizeX; overAx1++)
        {
            for (int overAx2 = 0; overAx2 <= mapSizeX; overAx2++)
            {



            }
        }
    }

    public Vector3 checkCoordinates(int[] gridToCheck)
    {
        return tiles.CellToLocal(new Vector3Int(gridToCheck[0], gridToCheck[1], 0));
    }

    public string checkTileType(int[] typeCheckLocation)
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

    public float checkTileHeight(int[] heightCheckLocation)
    {
        return height.GetTransformMatrix(new Vector3Int(heightCheckLocation[0], heightCheckLocation[1], 0))[1,3];
    }

    public int checkDataHeight(int[] dataHeightCheckLocation)
    {
        return data.GetInstantiatedObject(new Vector3Int(dataHeightCheckLocation[0], dataHeightCheckLocation[1], 0)).GetComponent<tileObjectScript>().height;
    }

    void changeTile(int[] changeLocation, string setType, Tile[] changeToTile, Tile[] changeToOverlay)
    {
        data.GetInstantiatedObject(new Vector3Int(changeLocation[0], changeLocation[1], 0)).GetComponent<tileObjectScript>().tileType = setType;
        tiles.SetTile(new Vector3Int(changeLocation[0], changeLocation[1], 0), changeToTile[2]);

        if (checkDataHeight(changeLocation) == 0)
        {
            raised0.SetTile(new Vector3Int(changeLocation[0], changeLocation[1], 0), changeToTile[0]);
        }
        if (checkDataHeight(changeLocation) == 1)
        {
            raised1.SetTile(new Vector3Int(changeLocation[0], changeLocation[1], 0), changeToTile[1]);
        }
        else if (checkDataHeight(changeLocation) == 2)
        {
            raised1.SetTile(new Vector3Int(changeLocation[0], changeLocation[1], 0), changeToTile[3]);
            raised2.SetTile(new Vector3Int(changeLocation[0], changeLocation[1], 0), changeToTile[1]);
        }
        else if (checkDataHeight(changeLocation) == 3)
        {
            raised1.SetTile(new Vector3Int(changeLocation[0], changeLocation[1], 0), changeToTile[3]);
            raised2.SetTile(new Vector3Int(changeLocation[0], changeLocation[1], 0), changeToTile[3]);
            raised3.SetTile(new Vector3Int(changeLocation[0], changeLocation[1], 0), changeToTile[1]);
        }
        else if (checkDataHeight(changeLocation) == 4)
        {
            raised1.SetTile(new Vector3Int(changeLocation[0], changeLocation[1], 0), changeToTile[3]);
            raised2.SetTile(new Vector3Int(changeLocation[0], changeLocation[1], 0), changeToTile[3]);
            raised3.SetTile(new Vector3Int(changeLocation[0], changeLocation[1], 0), changeToTile[3]);
            raised4.SetTile(new Vector3Int(changeLocation[0], changeLocation[1], 0), changeToTile[1]);

        }
        else if (checkDataHeight(changeLocation) == 5)
        {
            raised1.SetTile(new Vector3Int(changeLocation[0], changeLocation[1], 0), changeToTile[3]);
            raised2.SetTile(new Vector3Int(changeLocation[0], changeLocation[1], 0), changeToTile[3]);
            raised3.SetTile(new Vector3Int(changeLocation[0], changeLocation[1], 0), changeToTile[3]);
            raised4.SetTile(new Vector3Int(changeLocation[0], changeLocation[1], 0), changeToTile[3]);
            raised5.SetTile(new Vector3Int(changeLocation[0], changeLocation[1], 0), changeToTile[1]);
        }
        else if (checkDataHeight(changeLocation) == 6)
        {
            raised1.SetTile(new Vector3Int(changeLocation[0], changeLocation[1], 0), changeToTile[3]);
            raised2.SetTile(new Vector3Int(changeLocation[0], changeLocation[1], 0), changeToTile[3]);
            raised3.SetTile(new Vector3Int(changeLocation[0], changeLocation[1], 0), changeToTile[3]);
            raised4.SetTile(new Vector3Int(changeLocation[0], changeLocation[1], 0), changeToTile[3]);
            raised5.SetTile(new Vector3Int(changeLocation[0], changeLocation[1], 0), changeToTile[3]);
            raised6.SetTile(new Vector3Int(changeLocation[0], changeLocation[1], 0), changeToTile[1]);
        }

        overlay.SetTile(new Vector3Int(changeLocation[0], changeLocation[1], 0), changeToOverlay[0]);

        transformHold = overlay.GetTransformMatrix(new Vector3Int(changeLocation[0], changeLocation[1], 0));
        if (checkDataHeight(changeLocation) > 0)
        {
            transformHold[1, 3] = (checkDataHeight(changeLocation)) * 10;
        }
        else
        {
            transformHold[1, 3] = 0;
        }
        transformHold[2, 3] = (checkDataHeight(changeLocation)) * 25;
        overlay.SetTransformMatrix(new Vector3Int(changeLocation[0], changeLocation[1], 0), transformHold);
    }

    void showPointer()
    {
        effects.ClearAllTiles();

        effects.SetTile(new Vector3Int(pointerLocation[0], pointerLocation[1], 1), pointerTile);

        transformHold = height.GetTransformMatrix(new Vector3Int(pointerLocation[0], pointerLocation[1], 0));
        transformHold[2, 3] = (checkDataHeight(pointerLocation)) * 25;

        effects.SetTransformMatrix(new Vector3Int(pointerLocation[0], pointerLocation[1], 1), transformHold);
    }

    public void plantWheat(int[] wheatLocation)
    {
        if (checkTileType(wheatLocation) == "grass")
        {
            changeTile(wheatLocation, tileLibrary.wheatType[0], tileLibrary.wheat[0], tileLibrary.wheat[3]);
        }
    }

    public void plantPumpkins(int[] pumpkinLocation)
    {
        if (checkTileType(pumpkinLocation) == "grass")
        {
            changeTile(pumpkinLocation, tileLibrary.pumpkinType[0], tileLibrary.pumpkin[0], tileLibrary.pumpkin[3]);
        }
    }

    public void plantCandy(int[] candyLocation)
    {
        if (checkTileType(candyLocation) == "sand")
        {
            changeTile(candyLocation, "candy", tileLibrary.candy[0], tileLibrary.candy[0]);
        }
    }

    public void endTurn()
    {
        for (int axis1 = 0; axis1 <= mapSizeX; axis1++)
        {
            for (int axis2 = 0; axis2 <= mapSizeX; axis2++)
            {
                endLocation = new int[2] { axis1, axis2 };
                tileType = checkTileType(endLocation);

                if (tileType == tileLibrary.wheatType[0])
                {
                    changeTile(endLocation, tileLibrary.wheatType[1], tileLibrary.wheat[1], tileLibrary.wheat[4]);
                }
                else if (tileType == tileLibrary.wheatType[1])
                {
                    changeTile(endLocation, tileLibrary.wheatType[2], tileLibrary.wheat[2], tileLibrary.wheat[5]);
                }
                else if (tileType == tileLibrary.pumpkinType[0])
                {
                    changeTile(endLocation, tileLibrary.pumpkinType[1], tileLibrary.pumpkin[1], tileLibrary.pumpkin[4]);
                }
                else if (tileType == tileLibrary.pumpkinType[1])
                {
                    changeTile(endLocation, tileLibrary.pumpkinType[2], tileLibrary.pumpkin[2], tileLibrary.pumpkin[5]);
                }
            }
        }
    }

    public void movePointer(int moveDir)
    {
        /*
          
         | 3      0 |
         |          |
         | 2      1 |
          
        */

        if (moveDir == 0)
        {
            if (pointerLocation[0] < mapSize[0])
            {
                pointerLocation[0]++;
                showPointer();
            }
        }
        else if (moveDir == 1)
        {
            if (pointerLocation[1] > 0)
            {
                pointerLocation[1]--;
                showPointer();
            }

        }
        else if (moveDir == 2)
        {
            if (pointerLocation[0] > 0)
            {
                pointerLocation[0]--;
                showPointer();
            }
        }
        else if (moveDir == 3)
        {
            if (pointerLocation[1] < mapSize[1])
            {
                pointerLocation[1]++;
                showPointer();
            }
        }

    }

    void Update()
    {
        if (!initializeCheck)
        {
            initialize();
            initializeCheck = true;
        }

        if (Input.GetKeyDown(KeyCode.Tilde))
        {
            debugMode = !debugMode;
        }

        if (debugMode)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                movePointer(0);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                movePointer(1);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                movePointer(2);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                movePointer(3);
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log(checkDataHeight(pointerLocation));
                Debug.Log(data.GetInstantiatedObject(new Vector3Int(pointerLocation[0], pointerLocation[1], 0)).GetComponent<tileObjectScript>().tileType);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                plantWheat(pointerLocation);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                plantPumpkins(pointerLocation);
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                plantCandy(pointerLocation);
            }

            if (Input.GetKeyDown(KeyCode.G))
            {
                endTurn();
            }
        }
    }
}
