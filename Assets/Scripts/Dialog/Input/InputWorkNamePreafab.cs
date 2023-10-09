using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using UnityEngine.SceneManagement;

public class InputWorkNamePrefab : MonoBehaviour
{
    public ErrorAlert errorAlert;

    private bool isSameName;

    public string GetInputFieldText()
    {
        GameObject modal = this.gameObject.transform.Find("Modal").gameObject;
        string InputName = modal.transform.Find("InputNameField").GetComponent<TMP_InputField>().text;

        return(InputName);
    }

    public void DestroyModal()
    {
        isSameName = false;
        
        // ユーザーが入力した作品名を取得
        string NewWorkName = GetInputFieldText();

        if (string.IsNullOrEmpty(NewWorkName))
        {
            // 入力されてなかったらアラートダイアログを表示
            errorAlert.ShowUnSetInputFieldErrorModal(GlobalVariables.ParentsUI);
        }
        else
        {
            GameObject[] rootObjects = SceneManager.GetActiveScene().GetRootGameObjects();

            foreach (GameObject work in rootObjects)
            {
                if (work.transform.name == NewWorkName)
                {
                    Debug.Log("名前一緒だよ");
                    errorAlert.ShowSameNameErrorModal(GlobalVariables.ParentsUI);
                    isSameName = true;
                    break;
                }
            }

            if (!isSameName)
            {
                // 入力されてたら名前入力のPrefabを消す
                Destroy(this.gameObject);
                // 作品名の変更
                GlobalVariables.CurrentWork.transform.name = NewWorkName;
            }
        }
    }
}