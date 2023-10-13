using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Display.Production;

public class InputWorkElementPrefab : MonoBehaviour
{
    private GameObject ElementNamesList = GlobalVariables.content;
    public ErrorAlert errorAlert;

    private bool isSameName = false;

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
        string NewElementName = GetInputFieldText();

        if (string.IsNullOrEmpty(NewElementName))
        {
            // 入力されてなかったらアラートダイアログを表示
            errorAlert.ShowUnSetInputFieldErrorModal(GlobalVariables.ParentsUI);
        }

        else
        {
            foreach (Transform element in GlobalVariables.CurrentWork.transform)
            {
                if (element.name == NewElementName)
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
                
                // 表示名、オブジェクト名の変更
                ElementNamesList.transform.Find(ProductionManager.selectedGameObjects[0].transform.name).GetComponent<ElementNamePrefab>().ChangeElementNameText(NewElementName);
                ElementNamesList.transform.Find(ProductionManager.selectedGameObjects[0].transform.name).transform.name = NewElementName;
                            
                // 立体名を変更する
                ProductionManager.selectedGameObjects[0].transform.name = NewElementName;
                
                // undostackにPush
                UndoRedo.Production.UndoRedo.ChangeName();
            }
        }
    }
}