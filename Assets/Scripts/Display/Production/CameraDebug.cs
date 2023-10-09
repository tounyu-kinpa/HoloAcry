using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraDebug : MonoBehaviour
{
    float MouseZoomSpeed = 15.0f;
    public Camera cam;

    void Update()
    {
        CameraZoom();
    }

    void CameraZoom()
    {
        if (Input.touchCount == 2)
        {
            // get current touch positions
            Touch tZero = Input.GetTouch(0);
            Touch tOne = Input.GetTouch(1);
            // get touch position from the previous frame
            Vector2 tZeroPrevious = tZero.position - tZero.deltaPosition;
            Vector2 tOnePrevious = tOne.position - tOne.deltaPosition;

            float oldTouchDistance = Vector2.Distance(tZeroPrevious, tOnePrevious);
            float currentTouchDistance = Vector2.Distance(tZero.position, tOne.position);

            // get offset value
            float deltaDistance = oldTouchDistance - currentTouchDistance;
            Zoom(deltaDistance, 0.01f);
        }
    }


    void Zoom(float deltaMagnitudeDiff, float speed)
    {
        float z = cam.transform.localPosition.z + deltaMagnitudeDiff * speed;
        cam.transform.localPosition = new Vector3(cam.transform.localPosition.x, cam.transform.localPosition.y, z);;
    }

}
