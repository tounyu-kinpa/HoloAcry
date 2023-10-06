using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model
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
    private static Stack<Model> undoStack = new Stack<Model>();
    private static Stack<Model> redoStack = new Stack<Model>();
    Model NewValue = new Model();

    public void AssignPopValue(Model PopValue)
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
                cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                Element = cube;
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

    public Model NewModel()
    {
        NewValue.name = cube.transform.name;  
        NewValue.elementType = cube.tag;
        NewValue.position = cube.transform.localPosition;
        NewValue.scale = cube.transform.localScale;
        NewValue.rotate = cube.transform.localEulerAngles;

        MeshFilter cubeMeshFilter = cube.GetComponent<MeshFilter>();
        NewValue.meshVertices = cubeMeshFilter.mesh.vertices;

        Material cubeRenderer = cube.GetComponent<Renderer>().material;
        NewValue.color = cubeRenderer.color;
    }

    public void Undo()
    {
        if(undoStack.Count >= 2){
            // Stackから取り出して代入する関数
            Model UndoValue = undoStack.Pop();
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
        Model RedoValue = redoStack.Pop();
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