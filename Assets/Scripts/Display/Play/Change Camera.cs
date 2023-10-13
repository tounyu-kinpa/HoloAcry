using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public GameObject Main_Camera;
    public GameObject Black_Camera;
    public GameObject Camera4;
    private float MainecameraX = 2.5f;
    private float MaincameraY = -5.5f;
    private float MaincameraZ = -20.0f;

    public void OnClick()
    {
        Main_Camera.SetActive(true);
        Black_Camera.SetActive(true);
        Camera4.SetActive(false);
        Main_Camera.transform.position = new Vector3(MainecameraX, MaincameraY, MaincameraZ);
        
        Camera mainCamera = Main_Camera.GetComponent<Camera>();
        mainCamera.orthographic = true;
        mainCamera.orthographicSize = 8.0f;
    }
}
