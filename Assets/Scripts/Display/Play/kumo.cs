using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloud : MonoBehaviour
{
    public GameObject TargetObject;
    public Rigidbody TargetTransform;
    // Start is called before the first frame update
    void Start()
    {
        TargetObject=GameObject.Find("kumo1");
        TargetTransform=TargetObject.GetComponent<Rigidbody>();
    }
    public void OnClick()
    {
        TargetTransform.velocity=new Vector3(6.0f,0.0f,0.0f);
        
    }
}
