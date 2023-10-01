using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeColorModeButton : MonoBehaviour
{
    public TMP_Dropdown dropdown;

    public GameObject HSVModePanel;
    public GameObject RGBModePanel;

    public void ChangeMode()
    {
        if (dropdown.value == 0)
        {
            RGBMode();
        }
        else
        {
            HSVMode();
        }
    }

    void RGBMode ()
    {
        HSVModePanel.SetActive(false);
        RGBModePanel.SetActive(true);
    }

    void HSVMode ()
    {
        RGBModePanel.SetActive(false);
        HSVModePanel.SetActive(true);
    }
}