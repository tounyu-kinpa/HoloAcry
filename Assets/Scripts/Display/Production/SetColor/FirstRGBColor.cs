using UnityEngine;

public class FirstRGBColor : MonoBehaviour
{
    public SetRGBColor scriptRGB;

    void Awake()
    {
       scriptRGB.SetColor();
    }
}