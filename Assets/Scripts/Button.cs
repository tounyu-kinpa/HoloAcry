using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Button : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void ModeChange(Mode mode)
    {
        GameManager.CurrentMode = mode;
    }
    
}
