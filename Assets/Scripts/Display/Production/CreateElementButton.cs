using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateElementButton : MonoBehaviour
{
    public GameObject ElementPrefab;     // 生成するElementのPrefab
    public GameObject ElementNamePrefab; // ElementNameのPrefab
    public GameObject ElementNameList;   // ElementNameの親オブジェクト
    private int i = 0;                   // ElementNameの表示名変更用変数
    
    public void CreateElement()
    {
        // Elementを生成
        GameObject NewElement = Instantiate(ElementPrefab);
        GameObject NewElementName = Instantiate(ElementNamePrefab, ElementNameList.transform);

        // ゲームオブジェクト名の変更
        NewElementName.transform.name = i.ToString();
        NewElement.transform.name = i.ToString();

        // 表示名の変更
        ElementNamePrefab name = NewElementName.GetComponent<ElementNamePrefab>();
        name.ChangeElementNameText(i.ToString());

        i++;
    }
}