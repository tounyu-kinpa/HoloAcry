using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NAudio.Wave;

public class kaminari : MonoBehaviour
{
    public float aida; 
    public float kesu; 
    public float dasu; 
    public GameObject Thunder;
    
    // Start is called before the first frame update
    public void Start()
    {
        // 
        aida=Random.Range(0.8f,1.0f);
        kesu=Random.Range(0.7f,1.0f);
        dasu=Random.Range(0.3f,0.5f);
        Thunder.gameObject.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        dasu=Random.Range(0.3f,0.5f);
        audioSource.Play();
        Thunder.gameObject.SetActive(true);
        Invoke("thunder_move",aida);
    }
    public void thunder_move() {
        kesu=Random.Range(0.7f,1.0f);
        aida=Random.Range(0.8f,1.0f);
        Thunder.gameObject.SetActive(false);
    }
}
