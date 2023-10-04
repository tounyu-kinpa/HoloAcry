using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputName : MonoBehaviour
{
    public GameObject InputNameModal;
    public Transform Canvas;

    public void ShowInputNameModal()
    {
        Instantiate(InputNameModal, Canvas);
    }

    public string DeleteInputNameModal()
    {
        GameObject modal = InputNameModal.transform.Find("Modal").gameObject;
        string InputName = modal.transform.Find("InputNameField").GetComponent<InputField>().text;
        Destroy(InputNameModal);

        //取得した名前をreturn
        return(InputName);
    }
}