using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetInputField : MonoBehaviour
{
    // InputField
    private TMP_InputField inputField;

    // 現在の色を表示するためのRawImage
    public RawImage CurrentRGBColor;
    public RawImage CurrentHSVColor;

    // 各InputFieldに対応するHSV, RGBのスライダー
    public Slider HSVSlider;
    public Slider RGBSlider;

    // HSVモードのときのUI
    public GameObject HSVModePanel;

    // InputFieldのPlaceholder
    public TMP_Text placeholder;

    // HSVの値を0 - 1に変換するときの割る数
    public float HSVdivisor;

    private void Start()
    {
        inputField = this.gameObject.GetComponent<TMP_InputField>();
        ChangeInputFieldText(); 
    }

    // ユーザーがInputFieldに値を入力したときに呼び出す関数
    public void UpdateSliderValue()
    {
        // InputFieldの値をintにParse
        if (int.TryParse(inputField.text, out int inputValue))
        {
            // HSVモードの場合
            if (HSVModePanel.activeSelf)
            {
                // スライダーの値をユーザーが入力した値に対応させる
                HSVSlider.value = inputValue / HSVdivisor;
            }
            // RGBモードの場合
            else
            {
                RGBSlider.value = inputValue / 255f;
            }
        }
    }

    // スライダーの値が変更されたときに呼び出す関数
    public void ChangeInputFieldText()
    {
        if (HSVModePanel.activeSelf)
        {
            inputField.text = ((int)(HSVSlider.value * HSVdivisor)).ToString();
        }
        else 
        {
            inputField.text = ((int)(RGBSlider.value * 255)).ToString();
        }
    }

    // ユーザーがInputFieldに何も入力しなかったときに呼び出す関数
    public  void SetPlaceholder()
    {
        if (string.IsNullOrEmpty(inputField.text))
        {
            ChangeInputFieldText();
        }
    }
}