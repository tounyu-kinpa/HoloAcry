using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedModel
{
    public bool NowMaking = false;

    // Elementの名前を格納
    public string name;

    // Elementの種類を格納
    public string elementType;

    // ElementのlocalScaleを格納
    public Vector3 scale;

    // ElementのlocalPositionを格納
    public Vector3 position;

    // ElementのlocalEulerAnglesを格納
    public Vector3 rotate;

    // Elementのmeshの頂点座標を格納
    public Vector3[] meshVertices;

    public Color color;
}

public class UndoRedo : MonoBehaviour
{
    public static Stack<SelectedModel> undoStack = new Stack<SelectedModel>();
    public static Stack<SelectedModel> redoStack = new Stack<SelectedModel>();
    SelectedModel NewValue = new SelectedModel();

    public void AssignPopValue(SelectedModel PopValue)
    {
        //undoしたとき生成されたばかりだったら消去
        string ElementName = PopValue.name;
        GameObject Element = GameObject.Find(ElementName);

        if (PopValue.NowMaking == true){
            Destroy(Element);
        }
        else{
            //Destroy後のUndo,Redoの処理
            if (Element == null) {
                ProductionManager.selectedGameObjects[0] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                Element = ProductionManager.selectedGameObjects[0];
            }
                
            Element.tag = PopValue.elementType;
            Element.transform.name = PopValue.name;
            Element.transform.localPosition = PopValue.position;
            Element.transform.localScale = PopValue.scale;
            Element.transform.localEulerAngles = PopValue.rotate;

            MeshFilter ElementMeshFilter = Element.GetComponent<MeshFilter>();
            ElementMeshFilter.mesh.vertices = PopValue.meshVertices;

            Material ElementRenderer = Element.GetComponent<Renderer>().material;
            ElementRenderer.color = PopValue.color;
        }
        undoStack.Push(PopValue);
    }

    public void NewModel()
    {
        NewValue.name = ProductionManager.selectedGameObjects[0].transform.name;  
        NewValue.elementType = ProductionManager.selectedGameObjects[0].tag;
        NewValue.position = ProductionManager.selectedGameObjects[0].transform.localPosition;
        NewValue.scale = ProductionManager.selectedGameObjects[0].transform.localScale;
        NewValue.rotate = ProductionManager.selectedGameObjects[0].transform.localEulerAngles;

        MeshFilter selectedGameObjectMeshFilter = ProductionManager.selectedGameObjects[0].GetComponent<MeshFilter>();
        NewValue.meshVertices = selectedGameObjectMeshFilter.mesh.vertices;

        Material selectedGameObjectRenderer = ProductionManager.selectedGameObjects[0].GetComponent<Renderer>().material;
        NewValue.color = selectedGameObjectRenderer.color;
    }

    public void Undo()
    {
        if(undoStack.Count >= 2){
            // Stackから取り出して代入する関数
            SelectedModel UndoValue = undoStack.Pop();
            //変更後の情報を取り出してredostackにpush
            redoStack.Push(UndoValue);
            //変更前の情報を取り出して、その情報をもとにUndo
            UndoValue = undoStack.Pop();
            AssignPopValue (UndoValue);
        }
    }

    public void Redo()
    {
        // Stackから取り出して代入する関数
        SelectedModel RedoValue = redoStack.Pop();
        //取り出した変更後の情報をもとにRedo
        AssignPopValue (RedoValue);
    }

    public void Do()
    {
        NewModel();

        //変更後のObjectの値をまとめてUndoStackにPush
        NewValue.NowMaking = false;
        undoStack.Push(NewValue);
        // RedoをClear
        redoStack.Clear();
    }

}