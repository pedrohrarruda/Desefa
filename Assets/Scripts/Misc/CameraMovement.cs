using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    [SerializeField]
    private float zoomStep, minCamSize, maxCamSize;

    private Vector3 dragOrigin;

    void Update()
    {
        PanCamera();
        ZoomCamera();
    }

    private void PanCamera()
    {
        if(Input.GetMouseButtonDown(1))
            dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition); 

        if(Input.GetMouseButton(1))
        {
            Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition); 
            cam.transform.position += difference;
        }
    }

    private void ZoomCamera(){
        if(Input.mouseScrollDelta.y < 0) ZoomIn();
        else if(Input.mouseScrollDelta.y > 0) ZoomOut();
    }

    private void ZoomIn()
    {
        float newSize = cam.orthographicSize + zoomStep;

        cam.orthographicSize = Mathf.Clamp(newSize, minCamSize, maxCamSize);
    }

    private void ZoomOut()
    {
        float newSize = cam.orthographicSize - zoomStep;

        cam.orthographicSize = Mathf.Clamp(newSize, minCamSize, maxCamSize);
    }
}
