using UnityEngine;
using UnityEngine.UI;

public class SetHSVColor : MonoBehaviour
{
    public RawImage CurrentColor;
    
    public Slider hueSlider;
    public Slider saturationSlider;
    public Slider valueSlider;

    // スクロールバーの値に対応して現在の色の表示を変えるための関数
    public void SetColor()
    {
        // HSVからRGBに変換してImageのcolorを設定
        CurrentColor.color = Color.HSVToRGB(hueSlider.value, saturationSlider.value, valueSlider.value);
    }
}
