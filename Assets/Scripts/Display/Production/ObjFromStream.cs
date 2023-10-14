using Dummiesman;
using System.Collections;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class ObjFromStream : MonoBehaviour
{
    public GameObject inputField;

    public void CreateOBJ()
    {
        string str = inputField.GetComponent<FilePathInputField>().GetInputFieldText();

        Debug.Log(str);
        StartCoroutine(LoadObj(str));
    }

    IEnumerator LoadObj(string url)
    {
        // make UnityWebRequest
        using (var www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.LogError(www.error);
            }
            else
            {
                // create stream and load
                var textStream = new MemoryStream(Encoding.UTF8.GetBytes(www.downloadHandler.text));
                var loadedObj = new OBJLoader().Load(textStream);

                // 親オブジェクトを設定
                loadedObj.transform.parent = GlobalVariables.CurrentWork.transform;
            }
        }
    }
}

