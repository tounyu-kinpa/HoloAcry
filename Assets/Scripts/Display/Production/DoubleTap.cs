using System;
using UnityEngine;
namespace Display.Production
{
    public class DoubleTap : MonoBehaviour 
    {
        private void Update()
        {
            if (Input.touchCount == 1)
            {
                if (Input.touches[0].phase == TouchPhase.Began && Input.touches[0].tapCount == 2)
                {
                    Debug.Log("ダブルタッチ");
                }
            }
        }
    }
    
}

