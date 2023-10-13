using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Object_Deactive : MonoBehaviour
{
    public GameObject[] works_save;
    public void OnClick()
    {
        GameObject[] works = GameObject.FindGameObjectsWithTag("WorkSpace");
        works_save = works;
        foreach (GameObject work in works)
        {
            work.SetActive(false);
            if (work == works.Last())
            {
                work.SetActive(true);
            }
        }
    }
}
