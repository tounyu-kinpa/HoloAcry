using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Display.Production;
using UndoRedo.Production;

public class CreateElementButton : MonoBehaviour
{
    public GameObject ElementPrefab;     // 生成するElementのPrefab
    public GameObject ElementNamePrefab; // ElementNameのPrefab
    public GameObject ElementNameList;   // ElementNameの親オブジェクト
    private int i = 1;                   // ElementNameの表示名変更用変数

    private void Start() {
        GlobalVariables.content = this.ElementNameList;
    }
    
    public void CreateElement()
    {
        string NewName;

        // Elementを生成
        GameObject NewElement = Instantiate(ElementPrefab, GlobalVariables.CurrentWork.transform);
        GameObject NewElementName = Instantiate(ElementNamePrefab, ElementNameList.transform);

        NewName = SetElementName(NewElement.tag, i);

        // ゲームオブジェクト名の変更
        NewElementName.transform.name = NewName;
        NewElement.transform.name = NewName;

        // 表示名の変更
        ElementNamePrefab name = NewElementName.GetComponent<ElementNamePrefab>();
        name.ChangeElementNameText(NewName);

        i++;

        ProductionManager.selectedGameObjects = new List<GameObject> { NewElement };
        ProductionManager.createdGameObjects.Add(NewElement);

        UndoRedo.Production.UndoRedo.Create();
    }

    private string SetElementName(string tag, int i)
    {
        switch (tag)
        {
            case "Cube":
                return("直方体" + i.ToString());

            case "Ball":
                return("球" + i.ToString());

            case "Cylinder":
                return("円柱" + i.ToString());

            case "SquarePyramid":
                return("三角錐" + i.ToString());

            case "Cone":
                return("円錐" + i.ToString());
            
            default:
                return("未知" + i.ToString());
        }
    }
}