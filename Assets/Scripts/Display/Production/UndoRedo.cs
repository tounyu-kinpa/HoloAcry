// using System.Runtime.Intrinsics.X86;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Display.Production;

namespace UndoRedo.Production
{
    public class SelectedModel
    {
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

        // 結合したオブジェクトの数を格納
        public int ObjectCount = 0;

        // 結合したオブジェクトを判断
        public bool ChildObject = false;

        // UndoRedoされたオブジェクトがどういうオブジェクトなのか格納
        public string tag;
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
                if (UndoValue.ChildObject == true){
                    
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
            SelectedModel RedoValue = redoStack.Pop();
            if (RedoValue.ChildObject == true){
                undoStack.Push(RedoValue);
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
            SelectedModel DoValue =  NewModel(ProductionManager.selectedGameObjects[0]); 

            // 変更後のObjectの値をまとめてUndoStackにPush
            undoStack.Push(DoValue);
            // RedoをClear
            redoStack.Clear();
        }
        public void UndoRedoBranch(SelectedModel PopValue)
        { 
            ProductionManager.selectedGameObjects = new List<GameObject>{};
            GameObject Element = FindMatchingObjectID(PopValue.ObjectID);

            if (Element == null) {
                CreateElementButton InstanceCreateElement = new CreateElementButton();
                InstanceCreateElement.CreateElement();
                int ElementID = ProductionManager.selectedGameObjects[0].GetInstanceID();
                ElementID = PopValue.ObjectID;
                Element = FindMatchingObjectID(PopValue.ObjectID);
                AssignPopValue(PopValue, Element);
            }
            else{
                switch (PopValue.tag)
                {
                    // nowmaking true
                    case "NowCreat" :
                        DeleteElementButton InstanceDeleteElement = new DeleteElementButton();
                        InstanceDeleteElement.DestroyElement();
                        undoStack.Push(PopValue);

                    // PopValue.RedoParentObject false
                    case "MergeUndo" :
                        for(int i = 0; i < PopValue.ObjectCount; i++){
                            SelectedModel popValue = undoStack.Pop();
                            GameObject MergeElement = FindMatchingObjectID(popValue.ObjectID);
                            ProductionManager.selectedGameObjects.Add(MergeElement);
                            // AssignPopValue(popValue, MergeElement);
                        }
                        ProductionFunction.UnMergeObjects();

                    // PopValue.RedoParentObject true
                    case "MergeRedo" :
                        for(int i = 0; i < PopValue.ObjectCount; i++){
                            SelectedModel ChildObjectValue = undoStack.Pop();
                            GameObject ChiledElement = FindMatchingObjectID(PopValue.ObjectID);
                            ProductionManager.selectedGameObjects.Add(ChiledElement);
                            ProductionFunction.MergeObjects();
                        }
                    
                    default :
                        AssignPopValue(PopValue, Element);

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
            // CreateValue.NowMaking = true;
            CreateValue.tag = "NowCreat";
            undoStack.Push(CreateValue);
            Do(ProductionManager.selectedGameObjects[0]);
        }

        public static void Destroy()
        {
            Do(ProductionManager.selectedGameObjects[0]);
            SelectedModel DestroyValue = NewModel(ProductionManager.selectedGameObjects[0]);
            DestroyValue.tag = "NowCreat";
            undoStack.Push(DestroyValue);
        }

        //オブジェクト結合した時の処理
        public static void Merge()
        {
            SelectedModel MergeValue;
            int ChildCount = ProductionManager.selectedGameObjects[0].transform.childCount;  // 結合したオブジェクトの数を格納

            for (int i = 0; i <= ChildCount; i++){
                GameObject childObject = ProductionManager.selectedGameObjects[0].transform.GetChild(i).gameObject;
                MergeValue =  NewModel(childObject);
                MergeValue.ChildObject = true;
                MergeValue.ObjectCount = ChildCount;
                undoStack.Push(MergeValue);  
            }
            
            MergeValue = NewModel(ProductionManager.selectedGameObjects[0]);
            MergeValue.ObjectCount = ChildCount;
            MergeValue.tag = "MergeUndo";
            undoStack.Push(MergeValue);
            MergeValue.tag = "MergeRedo";
            undoStack.Push(MergeValue);
        }
    }
}