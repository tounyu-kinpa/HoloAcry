using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ImportButton : MonoBehaviour
{
    public Button FileButton;
    public Button URLButton;

    public TMP_InputField inputField;

    public void OnClickDoneFileButton()
    {
        // inputField.text を引数として呼び出す
        Debug.Log("ファイルからつくるよ");
    }

    public void OnClickDoneURLButton()
    {
        // Streamのやつの関数をinputField.text を引数として呼び出す
        Debug.Log("Streamからつくるよ");
    }
}