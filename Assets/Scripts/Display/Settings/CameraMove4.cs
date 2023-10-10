using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove4 : MonoBehaviour
{
    public GameObject Main_Camera;
    public GameObject Camera1;
    public GameObject Camera2;
    public GameObject Camera3;
    public GameObject Camera4;

    public void OnClick()
    {

        Main_Camera.SetActive(false);
        Camera1.SetActive(true);
        Camera2.SetActive(true);
        Camera3.SetActive(true);
        Camera4.SetActive(true);
    }
}
