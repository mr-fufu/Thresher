using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileObjectScript : MonoBehaviour
{
    public bool water;
    public bool grass;
    public bool sand;

    public string tileType;

    // Start is called before the first frame update
    void Start()
    {
        if (water)
        {
            tileType = "water";
        }
        else if (grass)
        {
            tileType = "grass";
        }
        else
        {
            tileType = "sand";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
