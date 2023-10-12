using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Object_Reactive : MonoBehaviour
{


    public void OnClick()
    {
        Object_Deactive object_deactive = GetComponent<Object_Deactive>();
        int n = 0;
        foreach (GameObject work in object_deactive.works_save)
        {
            work.SetActive(true);
            
        }
    }
}
