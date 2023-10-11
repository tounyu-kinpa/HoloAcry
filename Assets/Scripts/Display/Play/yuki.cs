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
    }
    public void Onclic(){
        particle.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
