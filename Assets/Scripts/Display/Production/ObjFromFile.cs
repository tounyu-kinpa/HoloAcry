using Dummiesman;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Display.Production;

public class ObjFromFile : MonoBehaviour
{
    public GameObject inputField;

    private string objPath;

    GameObject loadedObject;

    public void LoadButton() {
        Debug.Log("ファイルからのやつ");
        objPath = inputField.GetComponent<FilePathInputField>().GetInputFieldText();
        loadedObject = new OBJLoader().Load(objPath);
    }
}
