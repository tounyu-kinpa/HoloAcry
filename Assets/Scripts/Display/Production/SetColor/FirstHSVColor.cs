using UnityEngine;

public class FirstHSVColor : MonoBehaviour
{
    public SetHSVColor scriptHSV;
    public SetRawImageColor scriptRawImage;

    void Awake()
    {
       scriptHSV.SetColor();
       scriptRawImage.SetColor();
    }
}