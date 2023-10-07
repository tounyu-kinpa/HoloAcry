using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputNamePrefab : MonoBehaviour
{
    public ErrorAlert errorAlert = new ErrorAlert();

    public string GetInputFieldText()
    {
        GameObject modal = this.gameObject.transform.Find("Modal").gameObject;
        string InputName = modal.transform.Find("InputNameField").GetComponent<TMP_InputField>().text;

        return(InputName);
    }

    public void DestroyModal()
    {
        GlobalVariables.ParentsUI = this.SettingsUI.transform;
        
        // ユーザーが入力した作品名を取得
        string NewWorkName = GetInputFieldText();

        if (string.IsNullOrEmpty(NewWorkName))
        {
            // 入力されてなかったらアラートダイアログを表示
            errorAlert.ShowUnSetInputFieldErrorModal(GlobalVariables.ParentsUI);
        }
        else
        {
            // 入力されてたら名前入力のPrefabを消す
            Destroy(this.gameObject);
            // 作品名を変更する
            GlobalVariables.CurrentWork.transform.name = NewWorkName;
        }
    }
}