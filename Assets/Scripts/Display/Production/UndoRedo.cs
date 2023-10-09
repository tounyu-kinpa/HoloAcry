// using System.Runtime.Intrinsics.X86;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Display.Production;

public class SelectedModel
{
    //生成されたときにTrueにする値
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

    // Elementのcolorを格納
    public Color color;

    // selectedGameObjectsと一致するcreatedGameObjectsのインデックスを格納
    public int ObjectID;

    //結合したオブジェクトの数を格納
    public int ObjectCount = 0;

    public bool ChildObject = false;

    public bool RedoParentObject = false;
}

public class UndoRedo : MonoBehaviour
{
    public static Stack<SelectedModel> undoStack = new Stack<SelectedModel>();
    public static Stack<SelectedModel> redoStack = new Stack<SelectedModel>();

    public void Undo()
    {
        if(undoStack.Count >= 2){
            
            SelectedModel UndoValue = undoStack.Pop();
            redoStack.Push(UndoValue);

            //結合したオブジェクト分redostack.Pushする処理
            if (UndoValue.ChildObject == ture){
                
                for (int i = 0; i < UndoValue.ObjectCount ; i++){
                    SelectedModel undoChileVale = undoStack.Pop();
                    redoStack.Push(undoChileVale);
                }
            }
            //変更前の情報を取り出して、その情報をもとにUndo
            UndoValue = undoStack.Pop();
            UndoRedoBranch (UndoValue);
        }
    }

    public void Redo()
    {
        // Stackから取り出して代入する関数
        object RedoValue = redoStack.Pop();
        if (RedoValue.ChildObject == ture){
            undoStack.push(RedoValue);
            for (int i = 0; i < RedoValue.ObjectCount ; i++){
                SelectedModel redoChileVale = undoStack.Pop();
                undoStack.Push(redoChileVale);
            }
            RedoValue = redoStack.Pop();
        }
        //取り出した変更後の情報をもとにRedo
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
    public void UndoRedoBranch(SelectedModel PopValue)
    { 
        ProductionManager.selectedGameObjects = new List<GameObject>;
        GameObject Element = FindMatchingObjectID(PopValue.ObjectID);
        
        if(PopValue.ObjectCount > 0){
            // 結合をUndoした時
            if(PopValue.RedoParentObject != true){
                Destroy(Element);
                for(int i = 0; i < PopValue.ObjectCount; i++){
                    SelectedModel popValue = undoStack.Pop();
                    GameObject Element = FindMatchingObjectID(popValue.ObjectID);
                    Element.transform.parent = workspace.transform;
                    AssignPopValue(popValue, Element);
                }
            }
            // 結合をRedoした時
            else{
                SelectedModel Parent = PopValue;
                for(int i = 0; i < PopValue.ObjectCount; i++){
                    SelectedModel ChildObjectValue = undoStack.Pop();
                    GameObject ChileElement = FindMatchingObjectID(popValue.ObjectID);
                    ProductionManager.selectedGameObjects.Add(ChileElement);
                    ProductionFunction.MergeObjects();
                }
                
            }
            
        }
        else{
            // undoしたとき生成されたばかりだったらDestroy
            if (PopValue.NowMaking == true){
                Destroy(Element);
                undoStack.Push(PopValue);
            }
            else{
                // Destroy後のUndo,Redoの処理
                if (Element == null) {
                    CreateElementButton InstanceCreateElement = new CreateElementButton();
                    InstanceCreateElement.CreateElement();
                    int ElementID = ProductionManager.selectedGameObjects[0].GetInstanceID();
                    ElementID = PopValue.ObjectID;
                    Element = FindMatchingObjectID(PopValue.ObjectID);
                    AssignPopValue(PopValue, Element);
                }
                // その他のUndoRedo処理
                else{
                    AssignPopValue(PopValue, Element);
                }
            }
        }
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

        undoStack.Push(PopValue);
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
        int ChildCount = ProductionManager.selectedGameObjects[0].transform.childCount;

        for (int i = 0; i <= ChildCount; i++){
            GameObject childObject = ProductionManager.selectedGameObjects[0].transform.GetChild(i).gameObject;
            SelectedModel MergeValue =  NewModel(childObject);
            MerheValue.ChildObject = true;
            undoStack.Push(MergeValue);  
        }
        
        MergeValue = NewModel(ProductionManager.selectedGameObjects[0]);
        MergeValue.ObjectCount = ChildCount;
        undoStack.Push(MergeValue);
        MergeValue.RedoParentObject = true;
        undoStack.Push(MergeValue);
        
    }
}