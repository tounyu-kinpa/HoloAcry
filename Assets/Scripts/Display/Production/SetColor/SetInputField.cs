using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetInputField : MonoBehaviour
{
    private TMP_InputField inputField;

    public RawImage CurrentRGBColor;
    public RawImage CurrentHSVColor;

    public Slider HSVSlider;
    public Slider RGBSlider;

    public GameObject HSVModePanel;
    public GameObject RGBModePanel;

    public float HSVdivisor = 360;

    private void Start()
    {
        inputField = this.gameObject.GetComponent<TMP_InputField>();
        ChangeInputFieldText(); 
    }

    public void UpdateSliderValue()
    {
        if (HSVModePanel.activeSelf)
        {
            HSVSlider.value = int.Parse(inputField.text) / HSVdivisor;
        }
        else
        {
            RGBSlider.value = int.Parse(inputField.text) / 255f;
        }
    }

    // InputFieldのテキストを変更するメソッド
    private void SetInputFieldText(string newText)
    {
        inputField.text = newText;
    }

    public void ChangeInputFieldText()
    {
        if (HSVModePanel.activeSelf)
        {
            SetInputFieldText(((int)(HSVSlider.value * HSVdivisor)).ToString());
        }
        else 
        {
            SetInputFieldText(((int)(RGBSlider.value * 255)).ToString());
        }
    }
}