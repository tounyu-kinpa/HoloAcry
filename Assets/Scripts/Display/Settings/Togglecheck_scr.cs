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

    public void ToggleInteraction()
    {
        if (toggle.isOn == true)
        {
            toggle1.isOn = false;
            toggle2.isOn = false;
            toggle3.isOn = false;
            toggle4.isOn = false;
            toggle5.isOn = false;

            toggle1.interactable = false;
            toggle2.interactable = false;
            toggle3.interactable = false;
            toggle4.interactable = false;
            toggle5.interactable = false;
        }
        else
        {
            toggle1.interactable = true;
            toggle2.interactable = true;
            toggle3.interactable = true;
            toggle4.interactable = true;
            toggle5.interactable = true;
        }
    }
}
