using UnityEngine;
using UnityEngine.UI;

public class RawImageObject : MonoBehaviour
{
    public RawImage CurrentHSVColor;

    public Slider HSlider;
    public Slider SSlider;
    public Slider VSlider;

    public void OnClick()
    {
        float H, S, V;

        Color.RGBToHSV(this.gameObject.GetComponent<RawImage>().color, out H, out S, out V);

        CurrentHSVColor.color = this.gameObject.GetComponent<RawImage>().color;

        SSlider.value = S;
        VSlider.value = V;
    }
}