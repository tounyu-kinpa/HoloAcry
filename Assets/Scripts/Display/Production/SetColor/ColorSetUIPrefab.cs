using UnityEngine;
using UnityEngine.UI;
using Display.Production;

public class ColorSetUIPrefab : MonoBehaviour
{
    public RawImage CurrentHSVColor;
    public RawImage CurrentRGBColor;

    public GameObject HSVModePanel;

    public void DestroyColorSetUI()
    {
        Destroy(this.gameObject);
    }

    public void SetElementColor()
    {
        if (HSVModePanel.activeSelf)
        {
            ProductionFunction.ChangeColorRGB(CurrentHSVColor.color);
        }
        else
        {
            ProductionFunction.ChangeColorRGB(CurrentRGBColor.color);
        }
    }
}