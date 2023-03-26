using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraControler : MonoBehaviour
{
    [SerializeField] private int cameraZoomSensibility;
    [SerializeField] private int cameraSize;
    [SerializeField] private Camera mineCamera;
    [SerializeField] private Transform mineCameraTransform;
    

    private Vector2 cameraZoom;
    private void Update()
    {
        cameraZoom = Input.mouseScrollDelta;

        if (cameraZoom.y == 1)
        {
            cameraSize = cameraSize - 1 * cameraZoomSensibility;
            mineCamera.orthographicSize = cameraSize;
            cameraZoom.y = 0;
            
        }
        if (cameraZoom.y == -1)
        {
            cameraSize = cameraSize + 1 * cameraZoomSensibility;
            mineCamera.orthographicSize = cameraSize;
            cameraZoom.y = 0;
        }
        
    }
}
