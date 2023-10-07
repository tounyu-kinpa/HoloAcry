using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputNamePrefab : MonoBehaviour
{
    public string GetInputFieldText()
    {
        GameObject modal = this.gameObject.transform.Find("Modal").gameObject;
        string InputName = modal.transform.Find("InputNameField").GetComponent<TMP_InputField>().text;

        return(InputName);
    }

    public void DestroyModal()
    {
        Destroy(this.gameObject);
    }
}