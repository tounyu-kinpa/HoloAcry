using UnityEngine;
using UnityEngine.UI;

public class SetRGBColor : MonoBehaviour
{
    public RawImage CurrentColor;
    public Slider redSlider;
    public Slider greenSlider;
    public Slider blueSlider;

    public void SetColor()
    {
        CurrentColor.color = new Color(redSlider.value, greenSlider.value, blueSlider.value);
    }
}

