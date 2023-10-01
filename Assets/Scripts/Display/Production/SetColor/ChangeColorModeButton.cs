using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeColorModeButton : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    
    public Slider redSlider;
    public Slider greenSlider;
    public Slider blueSlider;
    public Slider hueSlider;
    public Slider saturationSlider;
    public Slider valueSlider;

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

    void RGBMode()
    {
        hueSlider.gameObject.SetActive(false);
        saturationSlider.gameObject.SetActive(false);
        valueSlider.gameObject.SetActive(false);

        redSlider.gameObject.SetActive(true);
        greenSlider.gameObject.SetActive(true);
        blueSlider.gameObject.SetActive(true);
    }

    void HSVMode ()
    {
        redSlider.gameObject.SetActive(false);
        greenSlider.gameObject.SetActive(false);
        blueSlider.gameObject.SetActive(false);

        hueSlider.gameObject.SetActive(true);
        saturationSlider.gameObject.SetActive(true);
        valueSlider.gameObject.SetActive(true);
    }
}