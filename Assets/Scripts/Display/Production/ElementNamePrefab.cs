using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Display.Production;

public class ElementNamePrefab : MonoBehaviour
{
    public void ChangeElementNameText(string NewName)
    {
        // 子オブジェクトのTextを取得
        GameObject ElementNameText = this.transform.GetChild(0).gameObject;
        // Textのコンポーネントを取得
        TextMeshProUGUI TextStr = ElementNameText.GetComponent<TextMeshProUGUI>();
        // 表示名の変更
        TextStr.text = NewName;
    }

    public void OnClick()
    {
        ProductionManager.selectedGameObjects = new List<GameObject>{ GlobalVariables.CurrentWork.transform.Find(this.gameObject.transform.name).gameObject };
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}