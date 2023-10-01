using UnityEngine;
using UnityEngine.UI;

public class SetHSVColor : MonoBehaviour
{
    public RawImage CurrentColor;
    public Slider hueSlider;
    public Slider saturationSlider;
    public Slider valueSlider;

    public void SetColor()
    {
        // HSVからRGBに変換してImageのcolorを設定
        CurrentColor.color = Color.HSVToRGB(hueSlider.value, saturationSlider.value, valueSlider.value);
    }
}
