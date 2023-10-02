using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeColorModeButton : MonoBehaviour
{
    public TMP_Dropdown dropdown;

    public GameObject HSVModePanel;
    public GameObject RGBModePanel;

    public SetInputField RorH;
    public SetInputField GorS;
    public SetInputField BorV;

    public void ChangeMode()
    {

        if (dropdown.value == 0)
        {
            RGBMode();
            RorH.ChangeInputFieldText();
            GorS.ChangeInputFieldText();
            BorV.ChangeInputFieldText();
        }
        else
        {
            HSVMode();
            RorH.ChangeInputFieldText();
            GorS.ChangeInputFieldText();
            BorV.ChangeInputFieldText();
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