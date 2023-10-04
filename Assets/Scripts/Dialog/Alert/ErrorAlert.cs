using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErrorAlert : MonoBehaviour
{
    public GameObject ErrorModal;
    public Transform Canvas;
    GameObject modal;
    GameObject ModalText;
    Text ErrorText;

    public void ShowNoInformErrorModal()
    {
        //完了ボタンが押されたとき、記入漏れがあったらErrorModalを表示
        modal = ErrorModal.transform.Find("Modal").gameObject;
        ModalText = modal.transform.Find("Label").gameObject;
        ErrorText = ModalText.GetComponent<Text>();
        ErrorText.text = "全て選択してください";
        Instantiate(ErrorModal, Canvas);
    }

    public void ShowNoSelectErrorModal()
    {
        //削除やカラー変更ボタンが押されたときオブジェクトが選択されていなかったらErrorModalを表示
        modal = ErrorModal.transform.Find("Modal").gameObject;
        ModalText = modal.transform.Find("Label").gameObject;
        ErrorText = ModalText.GetComponent<Text>();
        ErrorText.text = "オブジェクトを選択してください";
        Instantiate(ErrorModal, Canvas);     
    }

    public void DeleteErrorModal()
    {
        //ErrorModalの了解ボタンが押されたら
        Destroy(ErrorModal);
    }
}