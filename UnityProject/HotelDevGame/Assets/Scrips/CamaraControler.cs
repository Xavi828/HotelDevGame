using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraControler : MonoBehaviour
{
    [SerializeField] private float cameraZoomSensitivity;
    [SerializeField] private float cameraSize;
    [SerializeField] private float cameraMoveSensitivity;
    [SerializeField] private int maxZoom;
    [SerializeField] private int minZoom;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform mainCameraTransform;

    private float verticalSpeed;
    private float horizontalSpeed;
    
    private Vector2 vectorMovement;
    private Vector2 cameraZoom;

    private void Update()
    {
        #region CameraZoom
        float cameraZoom = Input.mouseScrollDelta.y;

        if (cameraZoom > 0)
        {
            if (mainCamera.orthographicSize > minZoom)
            {
                cameraSize -= cameraZoomSensitivity;
                cameraSize = Mathf.Max(cameraSize, minZoom);
                mainCamera.orthographicSize = cameraSize;
            }
        }

        else if (cameraZoom < 0)
        {
            if (mainCamera.orthographicSize < maxZoom)
            {
                cameraSize += cameraZoomSensitivity;
                cameraSize = Mathf.Min(cameraSize, maxZoom);
                mainCamera.orthographicSize = cameraSize;
            }
        }

        #endregion

        #region CameraMove

        horizontalSpeed = Input.GetAxisRaw("Horizontal");
        verticalSpeed = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(horizontalSpeed, verticalSpeed).normalized;
        mainCameraTransform.Translate(movement * cameraMoveSensitivity * Time.deltaTime * 2 * cameraSize);

        #endregion

    }
}
