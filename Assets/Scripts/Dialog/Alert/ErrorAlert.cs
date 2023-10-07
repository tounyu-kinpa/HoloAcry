using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ErrorAlert : MonoBehaviour
{
    public GameObject AlertModal;
    private GameObject modalPrefab;

    public void ShowNoInformErrorModal(Transform Canvas)
    {
        //鑑賞に関する設定に記入漏れがあった時

        modalPrefab = Instantiate(AlertModal, Canvas);

        // エラー文を表示するTextを取得
        TMP_Text ErrorText = FindErrorModalText();

        // エラー文を設定
        ErrorText.text = "全て選択してください";
    }

    public void ShowNoSelectErrorModal(Transform Canvas)
    {
        //削除やカラー変更ボタンが押されたときオブジェクトが選択されていなかった時

        modalPrefab = Instantiate(AlertModal, Canvas);
        // Textの取得
        TMP_Text ErrorText = FindErrorModalText();
        
        // エラー文を設定
        ErrorText.text = "オブジェクトを選択してください";

    }

    public void FileImportErrorModal(Transform Canvas){
        //インポートされたファイルがOBJファイル以外だった時

        modalPrefab = Instantiate(AlertModal, Canvas);
        // Textの取得
        TMP_Text ErrorText = FindErrorModalText();

        // エラー文を設定
        ErrorText.text = "OBJファイルのみインポートが可能です";
    }

    public void ShowUnSetInputFieldErrorModal(Transform Canvas)
    {
        // InputFieldに何も入力されてなかったとき

        modalPrefab = Instantiate(AlertModal, Canvas);
        // Textの取得
        TMP_Text ErrorText = FindErrorModalText();
        // エラー文の設定
        ErrorText.text = "名前を入力してください";
    }

    public TMP_Text FindErrorModalText()
    {
        // エラー文を表示するTextを取得
        GameObject modal = modalPrefab.transform.Find("Modal").gameObject;
        GameObject ModalText = modal.transform.Find("Label").gameObject;
        TMP_Text ErrorText = ModalText.GetComponent<TMP_Text>();

        return(ErrorText);
    }

    public void DeleteErrorModal()
    {
        //ErrorModalの了解ボタンが押されたらModalを削除
        Destroy(this.gameObject);
    }
}