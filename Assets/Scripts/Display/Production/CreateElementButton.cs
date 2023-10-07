using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateElementButton : MonoBehaviour
{
    public GameObject ElementPrefab;     // 生成するElementのPrefab
    public GameObject ElementNamePrefab; // ElementNameのPrefab
    public GameObject ElementNameList;   // ElementNameの親オブジェクト
    private int i = 0;                   // ElementNameの表示名変更用変数
    
    public GameObject CreateElement()
    {
        // Elementを生成
        GameObject NewElement = Instantiate(ElementPrefab, GlobalVariables.CurrentWork.transform);
        GameObject NewElementName = Instantiate(ElementNamePrefab, ElementNameList.transform);

        // ゲームオブジェクト名の変更
        NewElementName.transform.name = NewElement.tag + i.ToString();
        NewElement.transform.name = NewElement.tag + i.ToString();

        // 表示名の変更
        ElementNamePrefab name = NewElementName.GetComponent<ElementNamePrefab>();
        name.ChangeElementNameText(NewElement.tag + i.ToString());

        i++;

        UndoRedo.Create(NewElement);

        return (NewElement);
    }
}