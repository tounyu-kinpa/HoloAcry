using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove4 : MonoBehaviour
{
    public GameObject Main_Camera;
    public GameObject Black_Camera;
    public GameObject Camera4;

    public void OnClick()
    {

        Main_Camera.SetActive(false);
        Black_Camera.SetActive(true);
        Camera4.SetActive(true);
    }
}
