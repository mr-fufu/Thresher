using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManagementScript : MonoBehaviour
{
    public GameObject tilemap;
    public GameObject highlight;
    public GameObject objects;

    public GameObject summonLibrary;

    public int mapSizeX;
    public int mapSizeY;

    public string checkTileType;

    // Start is called before the first frame update
    void Start()
    {
        for (int axis1 = 0; axis1 <= mapSizeX; axis1++)
        {
            for (int axis2 = 0; axis2 <= mapSizeX; axis2++)
            {
                checkTileType = checkTile(axis1, axis2);
            }
        }
    }

    string checkTile(int ax1, int ax2)
    {
        return (tilemap.GetComponent<Tilemap>().GetInstantiatedObject(new Vector3Int(ax1, ax2, 0)).GetComponent<tileObjectScript>().tileType);
    }

    int checkTileHeight(int axi1, int axi2)
    {
        return Mathf.FloorToInt(tilemap.GetComponent<Tilemap>().GetInstantiatedObject(new Vector3Int(axi1, axi2, 0)).transform.position.y);
    }

    void changeTile(int changeTo1, int changeTo2, Tile changeToTile)
    {
        tilemap.GetComponent<Tilemap>().SetTile(new Vector3Int(changeTo1, changeTo2, 0), changeToTile);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
