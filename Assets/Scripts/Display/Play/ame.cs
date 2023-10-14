using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ame : MonoBehaviour
{
   
    [SerializeField] private ParticleSystem particle;
    // Start is called before the first frame update
    void Start()
    {
        // 音声ファイルを取得
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        particle.Pause();
        particle.gameObject.SetActive(true);
        audioSource.Play();
        Invoke("particle_Pause",25f);
    }
    public void particle_Pause(){
        particle.gameObject.SetActive(false);
    }
}

