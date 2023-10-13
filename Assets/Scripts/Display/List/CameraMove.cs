using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject Main_Camera;

    private float CreatecameraX = 2.5f;
    private float CreatecameraY = -5.5f;
    private float CreatecameraZ = -20.0f;
    
    private Camera mainCamera;

    private void Start() {
        mainCamera = Main_Camera.GetComponent<Camera>();
        ListCamera();
    }

    public void ListCamera()
    {
        Main_Camera.SetActive(true);
        Main_Camera.transform.position = new Vector3(CreatecameraX, CreatecameraY, CreatecameraZ);

        if (Main_Camera != null)
        {
            // 正射影に変更
            mainCamera.orthographic = true;
            mainCamera.orthographicSize = 8.0f;
        }
    }

    public void ProductionCamera()
    {
        if (Main_Camera != null)
        {
            mainCamera.orthographic = false;
            Main_Camera.transform.position = new Vector3(0.0f, 0.0f, -20.0f);
        }
    }
}