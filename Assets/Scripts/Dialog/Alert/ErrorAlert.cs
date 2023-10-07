using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErrorAlert : MonoBehaviour
{
    public GameObject ErrorModal;   // インスペクターから代入するErroModalのPrefab
    public Transform Canvas;        // インスペクターから代入する親オブジェクト

    public void ShowNoInformErrorModal()
    {
        //完了ボタンが押されたとき、記入漏れがあったらErrorModalを表示
        Text NoInformErrorStatement = FindErrorModalText();
        NoInformErrorStatement = "全て選択してください";
        Instantiate(ErrorModal, Canvas);
    }

    public void ShowNoSelectErrorModal()
    {
        //削除やカラー変更ボタンが押されたときオブジェクトが選択されていなかったらErrorModalを表示
        Text NoSelectErrorStatement = FindErrorModalText();
        NoSelectErrorStatement = "すべて選択してください";
        Instantiate(ErrorModal, Canvas);  
    }

    public void FileImportErrorModal(){
        //インポートされたファイルがOBJファイル以外だとErrorModalを表示
        Text FileImportStatement = FindErrorModalText();
        FileImportStatement = "OBJファイルのみインポートが可能です";
        Instantiate(ErrorModal, Canvas); 
    }

    public Text FindErrorModalText()
    {
        // ErrorModalのPrefabからエラー文を取得
        GameObject modal = ErrorModal.transform.Find("Modal").gameObject;
        GameObject ModalText = modal.transform.Find("Label").gameObject;
        Text ErrorText = ModalText.GetComponent<Text>();

        return(ErrorText);
    }

    public void DeleteErrorModal()
    {
        //ErrorModalの了解ボタンが押されたらModalを削除
        Destroy(ErrorModal);
    }
}