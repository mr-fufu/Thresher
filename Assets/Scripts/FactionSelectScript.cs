using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactionSelectScript : MonoBehaviour
{
    public string faction;
    public int factionNo;

    public GameObject factionFlag_gourd;
    public GameObject factionFlag_straw;
    public GameObject factionFlag_candy;

    public GameControllerScript controller;

    void Start()
    {
        factionNo = 1;
        updateFlags();
    }

    private void updateFlags()
    {
        if (factionNo == 0)
        {
            faction = "gourds";

            factionFlag_gourd.SetActive(true);
            factionFlag_straw.SetActive(false);
            factionFlag_candy.SetActive(false);
        }
        else if (factionNo == 1)
        {
            faction = "straw";

            factionFlag_gourd.SetActive(false);
            factionFlag_straw.SetActive(true);
            factionFlag_candy.SetActive(false);
        }
        else
        {
            faction = "candy";

            factionFlag_gourd.SetActive(false);
            factionFlag_straw.SetActive(false);
            factionFlag_candy.SetActive(true);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            factionNo--;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            factionNo++;
        }

        if (factionNo > 2)
        {
            factionNo -= 3;
        }
        else if (factionNo < 0)
        {
            factionNo += 3;
        }

        updateFlags();

        if (Input.GetKeyDown(KeyCode.A))
        {
            controller.factionSelect(faction);
        }
    }
}
