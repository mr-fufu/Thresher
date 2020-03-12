using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementControllerScript : MonoBehaviour
{
    public TileManagementScript tileManager;

    [System.NonSerialized]
    public int characterCount;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            tileManager.movePointer(0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            tileManager.movePointer(1);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            tileManager.movePointer(2);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            tileManager.movePointer(3);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            tileManager.plantPumpkins(tileManager.pointerLocation);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            tileManager.plantWheat(tileManager.pointerLocation);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            tileManager.plantCandy(tileManager.pointerLocation);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            tileManager.endTurn();
        }
    }
}