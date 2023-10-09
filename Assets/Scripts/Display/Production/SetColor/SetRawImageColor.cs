using UnityEngine;
using UnityEngine.UI;

public class SetRawImageColor : MonoBehaviour
{
    public RawImage[] listRawImages;

    public Slider hueSlider;

    // hueSliderの値に応じて上と横にあるRawImageの色相を変化させる関数
    public void SetColor()
    {
        UpdateColor(listRawImages[0], 0.0f, 1.0f);
        UpdateColor(listRawImages[1], 0.25f, 1.0f);
        UpdateColor(listRawImages[2], 0.5f, 1.0f);
        UpdateColor(listRawImages[3], 0.75f, 1.0f);

        UpdateColor(listRawImages[4], 1.0f, 1.0f);

        UpdateColor(listRawImages[5], 1.0f, 0.75f);
        UpdateColor(listRawImages[6], 1.0f, 0.5f);
        UpdateColor(listRawImages[7], 1.0f, 0.25f);
        UpdateColor(listRawImages[8], 1.0f, 0.0f);
    }

    private void UpdateColor(RawImage rawImage, float saturation, float value)
    {
        rawImage.color = Color.HSVToRGB(hueSlider.value, saturation, value); 
    }
}