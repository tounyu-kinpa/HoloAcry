// using System.Runtime.Intrinsics.X86;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DefaultNamespace;

public class SelectedModel
{
    public bool NowMaking = false;
    public bool NowMerge;

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

    // Elementのcolorを格納
    public Color color;

    // selectedGameObjectsと一致するcreatedGameObjectsのインデックスを格納
    public int ObjectID;
}

public class UndoRedo : MonoBehaviour
{
    public static Stack<object> undoStack = new Stack<object>();
    public static Stack<object> redoStack = new Stack<object>();

    public void Undo()
    {
        if(undoStack.Count >= 2){
            // Stackから取り出して代入する関数
            object UndoValue = undoStack.Pop();
            //変更後の情報を取り出してredostackにpush
            redoStack.Push(UndoValue);
            //変更前の情報を取り出して、その情報をもとにUndo
            UndoValue = undoStack.Pop();
            // SelectedModel SelectedModelUndoValue = (SelectedModel)UndoValue;
            UndoRedoBranch (UndoValue);
        }
    }

    public void Redo()
    {
        // Stackから取り出して代入する関数
        object RedoValue = redoStack.Pop();
        //取り出した変更後の情報をもとにRedo
        // SelectedModel SelectedModelRedoValue = (SelectedModel)RedoValue;
        UndoRedoBranch (RedoValue);
    }

    public static void Do()
    {
        object DoValue =  NewModel(ProductionManager.selectedGameObjects[0]); 

        // 変更後のObjectの値をまとめてUndoStackにPush
        undoStack.Push(DoValue);
        // RedoをClear
        redoStack.Clear();
    }

    public void AssignPopValue(SelectedModel PopValue, GameObject Element)
    {                
        Element.tag = PopValue.elementType;
        Element.transform.name = PopValue.name;
        Element.transform.localPosition = PopValue.position;
        Element.transform.localScale = PopValue.scale;
        Element.transform.localEulerAngles = PopValue.rotate;

        MeshFilter ElementMeshFilter = Element.GetComponent<MeshFilter>();
        ElementMeshFilter.mesh.vertices = PopValue.meshVertices;

        Material ElementRenderer = Element.GetComponent<Renderer>().material;
        ElementRenderer.color = PopValue.color;

        object PushValue = (object)PopValue;
        undoStack.Push(PushValue);
    }

    public void UndoRedoBranch(object popValue)
    { 
        // 結合の値をPopした時
        if(popValue is List<SelectedModel>){
            List<SelectedModel> PopValueList = (List<SelectedModel>)popValue;
            //NowMerge = true子をworkspaceへ出して親を消去(Undo)
            if(PopValueList[0].NowMerge == true){

            }
            //faleは子をselectedGameObjectにAddしてProdactionManager.MergeObjects()へ(Redo)
            else{

            }
        }
        else{
            SelectedModel PopValue = (SelectedModel)popValue;
            GameObject Element = FindMatchingObjectID(PopValue.ObjectID);
            //undoしたとき生成されたばかりだったら消去
            if (PopValue.NowMaking == true){
                Destroy(Element);
                undoStack.Push(popValue);
            }
            else{
                //Destroy後のUndo,Redoの処理
                if (Element == null) {
                    CreateElementButton InstanceCreateElement = new CreateElementButton();
                    InstanceCreateElement.CreateElement();
                    int ElementID = ProductionManager.selectedGameObjects[0].GetInstanceID();
                    ElementID = PopValue.ObjectID;
                    Element = FindMatchingObjectID(PopValue.ObjectID);
                    AssignPopValue(PopValue, Element);
                }
                else{
                    AssignPopValue(PopValue, Element);
                }
            }
        }
    }

    public static GameObject FindMatchingObjectID(int instanceID)
    {
        int index = ProductionManager.createdGameObjects.FindIndex(x => x.GetInstanceID() == instanceID);

        return (ProductionManager.createdGameObjects[index]);
    }

    public static SelectedModel NewModel(GameObject selectedGameObject)
    {
        SelectedModel NewValue = new SelectedModel();
        NewValue.ObjectID = selectedGameObject.GetInstanceID();
        NewValue.name = selectedGameObject.transform.name;  
        NewValue.elementType = selectedGameObject.tag;
        NewValue.position = selectedGameObject.transform.localPosition;
        NewValue.scale = selectedGameObject.transform.localScale;
        NewValue.rotate = selectedGameObject.transform.localEulerAngles;

        MeshFilter ElementMeshFilter = selectedGameObject.GetComponent<MeshFilter>();
        NewValue.meshVertices = ElementMeshFilter.mesh.vertices;

        Material ElementRenderer = selectedGameObject.GetComponent<Renderer>().material;
        NewValue.color = ElementRenderer.color;

        return(NewValue);
    }

    //オブジェクト生成した時の処理
    public static void Create()
    {
        SelectedModel CreateValue =  NewModel(ProductionManager.selectedGameObjects[0]);
        CreateValue.NowMaking = true;
        undoStack.Push(CreateValue);
        Do();
    }

    public static void Merge()
    {
        // 結合したオブジェクトをUndoStack.PushするためのList
        List<SelectedModel> MergeVale = new List<SelectedModel>(); 
        int ParentID = ProductionManager.selectedGameObjects[0].GetInstanceID(); 
        GameObject ParentObject = FindMatchingObjectID(ParentID);
        // 結合したオブジェクトの数
        int childCount = ParentObject.transform.childCount;
        MergeVale.Add(NewModel(ProductionManager.selectedGameObjects[0]));

        for (int i = 0; i < childCount; i++){
            GameObject childObject = ParentObject.transform.GetChild(i).gameObject;
            MergeVale.Add(NewModel(childObject));
        }

        MergeVale[0].NowMerge = true;
        undoStack.Push(MergeVale);
        MergeVale[0].NowMerge = false;
        undoStack.Push(MergeVale);      
    }
}