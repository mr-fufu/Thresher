using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileLibraryScript : MonoBehaviour
{
    public Tile sand_tile;
    public Tile water_tile;
    public Tile grass_tile;

    public Tile wheat_1;
    public Tile wheat_2;
    public Tile wheat_3;

    public Tile pumpkin_1;
    public Tile pumpkin_2;
    public Tile pumpkin_3;

    public Tile[] wheat;
    public Tile[] pumpkin;

    public string[] wheatType;
    public string[] pumpkinType;

    // Start is called before the first frame update
    void Start()
    {
        wheat = new Tile[3] { wheat_1, wheat_2, wheat_3};
        pumpkin = new Tile[3] { pumpkin_1, pumpkin_2, pumpkin_3 };

        wheatType = new string[3] { "wheat_1", "wheat_2", "wheat_3" };
        pumpkinType = new string[3] { "pumpkin_1", "pumpkin_2", "pumpkin_3" };
    }
}
