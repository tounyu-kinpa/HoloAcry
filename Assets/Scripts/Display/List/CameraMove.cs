using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject Createcamera;
    public float CreatecameraX = 5000;
    public float CreatecameraY = 1440;
    public float CreatecameraZ = -1000;
    public GameObject Create;

    // Start is called before the first frame update


    // Update is called once per frame
    public void OnClick()
    {
        Createcamera.SetActive(true);
        Createcamera.transform.position = new Vector3(CreatecameraX, CreatecameraY, CreatecameraZ);

    }
}