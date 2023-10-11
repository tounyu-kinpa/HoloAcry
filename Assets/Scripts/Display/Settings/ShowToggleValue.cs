using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ShowToggleValue : MonoBehaviour
{
    public Toggle IgnoreToggle;
    public Toggle Toggle1;
    public Toggle Toggle2;
    public Toggle Toggle3;
    public Toggle Toggle4;
    public Toggle Toggle5;

    public List<bool> ReturnToggleValue()
    {
        List<bool> returnValue = new List<bool> { IgnoreToggle.isOn, Toggle1.isOn, Toggle2.isOn, Toggle3.isOn, Toggle4.isOn, Toggle5.isOn };

        return returnValue;
    }
}