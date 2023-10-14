using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FilePathInputField : MonoBehaviour
{
    public string GetInputFieldText()
    {
        string InputName = this.gameObject.GetComponent<TMP_InputField>().text;
        
        return(InputName);
    }
}