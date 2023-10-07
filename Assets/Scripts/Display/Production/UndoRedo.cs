using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DefaultNamespace;

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
    // SelectedModel NewValue = new SelectedModel();

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

    public static void Do()
    {
        SelectedModel DoValue =  NewModel(ProductionManager.selectedGameObjects[0]);

        //変更後のObjectの値をまとめてUndoStackにPush
        DoValue.NowMaking = false;
        undoStack.Push(DoValue);
        // RedoをClear
        redoStack.Clear();
    }
    public void AssignPopValue(SelectedModel PopValue)
    {
        //undoしたとき生成されたばかりだったら消去
        GameObject Element = GameObject.Find(PopValue.name);

        if (PopValue.NowMaking == true){
            Destroy(Element);
        }
        else{
            //Destroy後のUndo,Redoの処理
            if (Element == null) {
                CreateElementButton InstanceCreateElement = new CreateElementButton();
                ProductionManager.selectedGameObjects[0] = InstanceCreateElement.CreateElement();
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

    public static SelectedModel NewModel(GameObject Element)
    {
        SelectedModel NewValue = new SelectedModel();
        NewValue.name = Element.transform.name;  
        NewValue.elementType = Element.tag;
        NewValue.position = Element.transform.localPosition;
        NewValue.scale = Element.transform.localScale;
        NewValue.rotate = Element.transform.localEulerAngles;

        MeshFilter ElementMeshFilter = Element.GetComponent<MeshFilter>();
        NewValue.meshVertices = ElementMeshFilter.mesh.vertices;

        Material ElementRenderer = Element.GetComponent<Renderer>().material;
        NewValue.color = ElementRenderer.color;

        return(NewValue);
    }

    //オブジェクト生成した時の処理
    public static void Create(GameObject NewElement)
    {
        SelectedModel CreateValue =  NewModel(NewElement);
        CreateValue.NowMaking = true;
        undoStack.Push(CreateValue);
        Do();
    }
}