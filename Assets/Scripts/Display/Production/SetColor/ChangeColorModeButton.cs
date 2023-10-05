using UnityEngine;
using UnityEngine.UI;
using TMPro;

// SetColorUIのドロップダウンにアサインするクラス
public class ChangeColorDropDown : MonoBehaviour
{
    public TMP_Dropdown dropdown;

    public GameObject HSVModePanel;
    public GameObject RGBModePanel;

    public SetInputField RorH;
    public SetInputField GorS;
    public SetInputField BorV;

    // RGBとHSVのモードが変更されたとき呼び出す関数
    public void ChangeMode()
    {

        if (dropdown.value == 0)
        {
            RGBMode();
            // スクロールバーの値とInputFieldの値をそろえる
            RorH.ChangeInputFieldText();
            GorS.ChangeInputFieldText();
            BorV.ChangeInputFieldText();
        }
        else
        {
            HSVMode();
            // スクロールバーの値とInputFieldの値をそろえる
            RorH.ChangeInputFieldText();
            GorS.ChangeInputFieldText();
            BorV.ChangeInputFieldText();
        }
    }

    // ドロップダウンでRGBが選択されたときに実行する関数
    void RGBMode ()
    {
        // 対応するUIを表示させる
        HSVModePanel.SetActive(false);
        RGBModePanel.SetActive(true);
    }

    // ドロップダウンでHSVが選択されたときに実行する関数
    void HSVMode ()
    {
        // 対応するUIを表示させる
        RGBModePanel.SetActive(false);
        HSVModePanel.SetActive(true);
    }
}