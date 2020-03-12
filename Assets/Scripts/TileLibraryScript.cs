using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileLibraryScript : MonoBehaviour
{
    public Tile filler_grass;

    public Tile sand_tile_H1;
    public Tile sand_tile_H2;
    public Tile sand_tile_H3;
    public Tile water_tile_H1;
    public Tile water_tile_H2;
    public Tile water_tile_H3;

    public Tile grass_tile_H0;
    public Tile grass_tile_H1;
    public Tile grass_tile_H2;
    public Tile grass_tile_H3;

    //-----------------------

    public Tile wheat_1_H0;
    public Tile wheat_1_H1;
    public Tile wheat_1_H2;
    public Tile wheat_1_H3;

    public Tile wheat_2_H0;
    public Tile wheat_2_H1;
    public Tile wheat_2_H2;
    public Tile wheat_2_H3;

    public Tile wheat_3_H0;
    public Tile wheat_3_H1;
    public Tile wheat_3_H2;
    public Tile wheat_3_H3;

    //-----------------------

    public Tile pumpkin_1_H0;
    public Tile pumpkin_1_H1;
    public Tile pumpkin_1_H2;
    public Tile pumpkin_1_H3;

    public Tile pumpkin_2_H0;
    public Tile pumpkin_2_H1;
    public Tile pumpkin_2_H2;
    public Tile pumpkin_2_H3;

    public Tile pumpkin_3_H0;
    public Tile pumpkin_3_H1;
    public Tile pumpkin_3_H2;
    public Tile pumpkin_3_H3;

    public Tile candy_H0;
    public Tile candy_H1;
    public Tile candy_H2;
    public Tile candy_H3;

    //-----------------------

    public Tile overlay_grass_tile_H0;
    public Tile overlay_grass_tile_H1;
    public Tile overlay_grass_tile_H2;
    public Tile overlay_grass_tile_H3;

    //-----------------------

    public Tile overlay_wheat_1_H0;
    public Tile overlay_wheat_1_H1;
    public Tile overlay_wheat_1_H2;
    public Tile overlay_wheat_1_H3;

    public Tile overlay_wheat_2_H0;
    public Tile overlay_wheat_2_H1;
    public Tile overlay_wheat_2_H2;
    public Tile overlay_wheat_2_H3;

    public Tile overlay_wheat_3_H0;
    public Tile overlay_wheat_3_H1;
    public Tile overlay_wheat_3_H2;
    public Tile overlay_wheat_3_H3;

    //-----------------------

    public Tile overlay_pumpkin_1_H0;
    public Tile overlay_pumpkin_1_H1;
    public Tile overlay_pumpkin_1_H2;
    public Tile overlay_pumpkin_1_H3;

    public Tile overlay_pumpkin_2_H0;
    public Tile overlay_pumpkin_2_H1;
    public Tile overlay_pumpkin_2_H2;
    public Tile overlay_pumpkin_2_H3;

    public Tile overlay_pumpkin_3_H0;
    public Tile overlay_pumpkin_3_H1;
    public Tile overlay_pumpkin_3_H2;
    public Tile overlay_pumpkin_3_H3;

    public Tile overlay_candy_H0;
    public Tile overlay_candy_H1;
    public Tile overlay_candy_H2;
    public Tile overlay_candy_H3;

    [System.NonSerialized]
    public Tile[][] grass;
    [System.NonSerialized]
    public Tile[] sand;
    [System.NonSerialized]
    public Tile[] water;

    [System.NonSerialized]
    public Tile[][] wheat;
    [System.NonSerialized]
    public Tile[][] pumpkin;
    [System.NonSerialized]
    public Tile[][] candy;

    [System.NonSerialized]
    public string[] wheatType;
    [System.NonSerialized]
    public string[] pumpkinType;

    // Start is called before the first frame update
    void Start()
    {
        /*
        grass = new Tile[2][] { new Tile[5] { grass_tile_H0, grass_tile_H1, grass_tile_H2, grass_tile_H3 , filler_grass},
                                new Tile[4] { overlay_grass_tile_H0, overlay_grass_tile_H1, overlay_grass_tile_H2, overlay_grass_tile_H3 } };

        sand = new Tile[5] { null, sand_tile_H1, sand_tile_H2, sand_tile_H3, sand_tile_H1};
        water = new Tile[5] { null, water_tile_H1, water_tile_H2, water_tile_H3, water_tile_H1 };

        //wheat = new Tile[3 , 3] { { wheat_1_H1, wheat_2_H1, wheat_3_H1 }, { wheat_1_H2, wheat_2_H2, wheat_3_H2 }, { wheat_1_H3, wheat_2_H3, wheat_3_H3 } };
        //pumpkin = new Tile[3 , 3] { { pumpkin_1_H1, pumpkin_2_H1, pumpkin_3_H1 }, { pumpkin_1_H1, pumpkin_2_H1, pumpkin_3_H1 }, { pumpkin_1_H1, pumpkin_2_H1, pumpkin_3_H1 } };

        wheat = new Tile[6][] { new Tile[5]{ wheat_1_H0, wheat_1_H1, wheat_1_H2, wheat_1_H3, filler_grass }, 
                                new Tile[5]{ wheat_2_H0, wheat_2_H2, wheat_2_H2, wheat_2_H2, filler_grass }, 
                                new Tile[5]{ wheat_3_H0, wheat_3_H3, wheat_3_H3, wheat_3_H3, filler_grass },
                                new Tile[4]{ overlay_wheat_1_H0, overlay_wheat_1_H1, overlay_wheat_1_H2, overlay_wheat_1_H3 },
                                new Tile[4]{ overlay_wheat_2_H0, overlay_wheat_2_H1, overlay_wheat_2_H2, overlay_wheat_2_H3 },
                                new Tile[4]{ overlay_wheat_3_H0, overlay_wheat_3_H1, overlay_wheat_3_H2, overlay_wheat_3_H3 }};

        pumpkin = new Tile[6][] { new Tile[5] { pumpkin_1_H0, pumpkin_1_H1, pumpkin_1_H2, pumpkin_1_H3 , filler_grass}, 
                                  new Tile[5] { pumpkin_2_H0, pumpkin_2_H1, pumpkin_2_H2, pumpkin_2_H3 , filler_grass}, 
                                  new Tile[5] { pumpkin_3_H0, pumpkin_3_H1, pumpkin_3_H2, pumpkin_3_H3 , filler_grass},
                                  new Tile[4] { overlay_pumpkin_1_H0, overlay_pumpkin_1_H1, overlay_pumpkin_1_H2, overlay_pumpkin_1_H3,},
                                  new Tile[4] { overlay_pumpkin_2_H0, overlay_pumpkin_2_H1, overlay_pumpkin_2_H2, overlay_pumpkin_2_H3,},
                                  new Tile[4] { overlay_pumpkin_3_H0, overlay_pumpkin_3_H1, overlay_pumpkin_3_H2, overlay_pumpkin_3_H3,}};

        candy = new Tile[2][] { new Tile[5] { candy_H0, candy_H1, candy_H2, candy_H3, sand_tile_H1 },
                                new Tile[4] { overlay_candy_H0, overlay_candy_H1, overlay_candy_H2, overlay_candy_H3} };
        */

        grass = new Tile[2][] { new Tile[4] { grass_tile_H0, grass_tile_H1, grass_tile_H3, filler_grass },
                                new Tile[1] { overlay_grass_tile_H0 } };

        sand = new Tile[4] { null, sand_tile_H1, sand_tile_H3, sand_tile_H1 };
        water = new Tile[4] { null, water_tile_H1, water_tile_H3, water_tile_H1 };

        //wheat = new Tile[3 , 3] { { wheat_1_H1, wheat_2_H1, wheat_3_H1 }, { wheat_1_H2, wheat_2_H2, wheat_3_H2 }, { wheat_1_H3, wheat_2_H3, wheat_3_H3 } };
        //pumpkin = new Tile[3 , 3] { { pumpkin_1_H1, pumpkin_2_H1, pumpkin_3_H1 }, { pumpkin_1_H1, pumpkin_2_H1, pumpkin_3_H1 }, { pumpkin_1_H1, pumpkin_2_H1, pumpkin_3_H1 } };

        wheat = new Tile[6][] { new Tile[4]{ wheat_1_H0, wheat_1_H1, wheat_1_H3, filler_grass },
                                new Tile[4]{ wheat_2_H0, wheat_2_H1, wheat_2_H3, filler_grass },
                                new Tile[4]{ wheat_3_H0, wheat_3_H1, wheat_3_H3, filler_grass },
                                new Tile[1]{ overlay_wheat_1_H0 },
                                new Tile[1]{ overlay_wheat_2_H0 },
                                new Tile[1]{ overlay_wheat_3_H0 }};

        pumpkin = new Tile[6][] { new Tile[4] { pumpkin_1_H0, pumpkin_1_H1, pumpkin_1_H3, filler_grass },
                                  new Tile[4] { pumpkin_2_H0, pumpkin_2_H1, pumpkin_2_H3, filler_grass },
                                  new Tile[4] { pumpkin_3_H0, pumpkin_3_H1, pumpkin_3_H3, filler_grass },
                                  new Tile[1] { overlay_pumpkin_1_H0},
                                  new Tile[1] { overlay_pumpkin_2_H0},
                                  new Tile[1] { overlay_pumpkin_3_H0}};

        candy = new Tile[2][] { new Tile[4] { candy_H0, candy_H1, candy_H3, sand_tile_H1 },
                                new Tile[1] { overlay_candy_H0} };

        wheatType = new string[3] { "wheat_1", "wheat_2", "wheat_3" };
        pumpkinType = new string[3] { "pumpkin_1", "pumpkin_2", "pumpkin_3" };
    }
}
