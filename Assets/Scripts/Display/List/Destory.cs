using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Destory : MonoBehaviour
{
    public Transform content;

    public void OnClick()
    {
        
        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }
    }
    
}
