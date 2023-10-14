using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yuki : MonoBehaviour
{
     [SerializeField] private ParticleSystem particle;
    // Start is called before the first frame update
    void Start()
    {
        particle.Pause();
        audioSource = GetComponent<AudioSource();
        audioSource.clip = audioClip;
    }
    public void Onclic(){
        particle.gameObject.SetActive(true);
        audioSource.Play();
        Invoke("particle_Pause",25f);
    }
    public void particle_Pause(){
        particle.gameObject.SetActive(false);
    }
}
