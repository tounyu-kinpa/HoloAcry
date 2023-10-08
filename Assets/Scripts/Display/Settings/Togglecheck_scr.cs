using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Togglecheck_scr : MonoBehaviour
{
    public Toggle toggle;
    public Toggle toggle1;
    public Toggle toggle2;
    public Toggle toggle3;
    public Toggle toggle4;
    public Toggle toggle5;


    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (toggle.isOn == true)
        {
            togglesetactive();
        }
    }
    void togglesetactive()
    {
        toggle1.isOn = false;
        toggle2.isOn = false;
        toggle3.isOn = false;
        toggle4.isOn = false;
        toggle5.isOn = false;
    }
}
