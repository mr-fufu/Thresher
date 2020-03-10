using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera mainCamera;
    public GameManagementScript gameManager;
    public int[] toLocation;
    private Vector3 toVector;
    private float scale;
    private bool toggle;

    void Start()
    {
        mainCamera = GetComponent<Camera>();
        toLocation = new int[2] { 0, 250 };
    }

    void Update()
    {
        if (toggle)
        {
            toVector = gameManager.checkCoordinates(gameManager.pointerLocation);
            scale = 200;
        }
        else
        {
            toLocation = new int[2] { 0, 250 };
            toVector.x = toLocation[0];
            toVector.y = toLocation[1];
            scale = 400;
        }

        transform.position = Vector3.Lerp(transform.position, toVector, 0.125f);
        mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, scale, 0.5f);
    }

    public void toggleZoomToPointer()
    {
        toggle = !toggle;
    }
}
