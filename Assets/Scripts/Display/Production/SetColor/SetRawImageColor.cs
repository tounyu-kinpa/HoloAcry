using UnityEngine;
using UnityEngine.UI;

public class SetRawImageColor : MonoBehaviour
{
    // public RawImage S0V4;
    // public RawImage S0V3;
    // public RawImage S0V2;
    // public RawImage S0V1;
    // public RawImage S0V0;
    // public RawImage S1V0;
    // public RawImage S2V0;
    // public RawImage S3V0;
    // public RawImage S4V0;

    public RawImage[] listRawImages;

    public Slider hueSlider;

    private void SetColor(RawImage rawImage, float saturation, float value)
    {
        rawImage.color = Color.HSVToRGB(hueSlider.value, saturation, value); 
    }

    public void UpdateColor()
    {
        SetColor(listRawImages[0], 0.0f, 1.0f);
        SetColor(listRawImages[1], 0.25f, 1.0f);
        SetColor(listRawImages[2], 0.5f, 1.0f);
        SetColor(listRawImages[3], 0.75f, 1.0f);

        SetColor(listRawImages[4], 1.0f, 1.0f);

        SetColor(listRawImages[5], 1.0f, 0.75f);
        SetColor(listRawImages[6], 1.0f, 0.5f);
        SetColor(listRawImages[7], 1.0f, 0.25f);
        SetColor(listRawImages[8], 1.0f, 0.0f);
        
    }
}