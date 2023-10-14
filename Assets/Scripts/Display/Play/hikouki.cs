using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hikouki : MonoBehaviour
{
    public GameObject TargetObject;
    public Rigidbody TargetTransform;
    // Start is called before the first frame update
    void Start()
    {
        TargetTransform=TargetObject.GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
    }
    public void OnClick()
    {
        TargetTransform.velocity=new Vector3(6.0f,0.0f,0.0f);
        audioSource.Play();
        Invoke("object_reset",5.0f);
    }
    private void object_reset()
    {
        TargetTransform.velocity=new Vector3(0.0f,0.0f,0.0f);
        Destroy(gameObject);
    }
}
