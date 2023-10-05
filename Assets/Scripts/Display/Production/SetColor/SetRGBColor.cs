using UnityEngine;
using UnityEngine.UI;

// 
public class SetRGBColor : MonoBehaviour
{
    public RawImage CurrentColor;
    public Slider redSlider;
    public Slider greenSlider;
    public Slider blueSlider;

    // スクロールバーの値に対応して現在の色の表示を変えるための関数
    public void SetColor()
    {
        CurrentColor.color = new Color(redSlider.value, greenSlider.value, blueSlider.value);
    }
}

