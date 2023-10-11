using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove4 : MonoBehaviour
{
    public GameObject Main_Camera;
    public GameObject Black_Camera;
    public GameObject Camera4;

    private float camera4X = 0;
    private float camera4Y = 0;
    private float camera4Z = 0;

    public void OnClick()
    {
        Main_Camera.SetActive(false);
        Black_Camera.SetActive(true);
        Camera4.transform.position = new Vector3(camera4X, camera4Y, camera4Z);
        Camera4.SetActive(true);
    }
}
