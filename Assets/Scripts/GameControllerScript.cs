using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public bool factionChosen;
    public string faction;

    public GameObject factionSelectScreen;

    public bool inPlacement;
    public int characterCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void factionSelect(string chosenFaction)
    {
        factionChosen = true;
        faction = chosenFaction;
        factionSelectScreen.SetActive(false);
        inPlacement = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!factionChosen)
        {
            factionSelectScreen.SetActive(true);
        }
    }
}
