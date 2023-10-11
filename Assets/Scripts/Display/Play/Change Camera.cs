using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public GameObject Main_Camera;
    public GameObject Black_Camera;
    public GameObject Camera4;
    public float MainecameraX = 900;
    public float MaincameraY = 1440;
    public float MaincameraZ = -1000;

    public void OnClick()
    {
        Main_Camera.SetActive(true);
        Black_Camera.SetActive(true);
        Camera4.SetActive(false);
        Main_Camera.transform.position = new Vector3(MainecameraX, MaincameraY, MaincameraZ);
    }
}
