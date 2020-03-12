using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    [System.NonSerialized]
    public bool factionChosen;
    [System.NonSerialized]
    public string faction;

    public CameraController mainCamera;

    public GameObject factionSelectScreen;
    public GameObject placementController;

    [System.NonSerialized]
    public bool inPlacement;

    // Start is called before the first frame update
    void Start()
    {
        placementController.SetActive(false);
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
        if (!factionChosen && !factionSelectScreen.activeSelf)
        {
            factionSelectScreen.SetActive(true);
        }

        if (inPlacement && !placementController.activeSelf)
        {
            mainCamera.toggleZoomToPointer();
            placementController.SetActive(true);
        }
    }
}
