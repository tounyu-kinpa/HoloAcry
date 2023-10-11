using System.Net.Security;
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

        // Undo用の値かを判断
        public bool Undotag;
    }

    public class UndoRedo : MonoBehaviour
    {

        public static Stack<SelectedModel> undoStack = new Stack<SelectedModel>();
        public static Stack<SelectedModel> redoStack = new Stack<SelectedModel>();  
        private static Stack<SelectedModel> SaveStack = new Stack<SelectedModel>(); 

        public static void Undo()
        {
            if(undoStack.Count >= 2){
  
                SelectedModel UndoValue = undoStack.Pop();
                // 結合したオブジェクト分redostack.Pushする処理
                if (UndoValue.ChildObject == true){
                    for (int i = 0; i < UndoValue.ObjectCount ; i++){
                        SelectedModel undoChileVale = undoStack.Pop();
                        redoStack.Push(undoChileVale);
                    }
                    UndoValue = undoStack.Pop();
                }
                
                // UndotagがtrueならredoStackにPush
                if (UndoValue.Undotag == true){
                    if(redoStack.Count != 0){
                        redoStack.Push(UndoValue);
                    }
                    UndoValue = undoStack.Pop();
                }
                redoStack.Push(UndoValue);
                
                // 変更前の情報を取り出して、その情報をもとにUndo
                UndoValue = undoStack.Pop();
                UndoRedoBranch (UndoValue);
                // UndoValue.Undotag = true;
                undoStack.Push(UndoValue);
            }

        }

        public static void Redo()
        {
            // Stackから取り出して代入する関数
            SelectedModel RedoValue = redoStack.Pop();
            
            // 結合したオブジェクト分undo.Pushする処理
            if (RedoValue.ChildObject == true){
                undoStack.Push(RedoValue);
                for (int i = 0; i < RedoValue.ObjectCount ; i++){
                    SelectedModel redoChileVale = undoStack.Pop();
                    undoStack.Push(redoChileVale);
                }
                RedoValue = redoStack.Pop();
            }

            // Undo用の値だったらundo.Push
            if(RedoValue.Undotag == true){
                undoStack.Push(RedoValue);
                RedoValue = redoStack.Pop();
            }
            
            //取り出した変更後の情報をもとにRedo
            UndoRedoBranch (RedoValue);
            undoStack.Push(RedoValue);
            
        }

        public static void Do(GameObject SelectedObject, bool Undotag = false)
        {
            SelectedModel DoValue =  NewModel(SelectedObject); 
            DoValue.Undotag = Undotag;

            // 変更後のObjectの値をまとめてUndoStackにPush
            undoStack.Push(DoValue);
            // RedoをClear
            redoStack.Clear();
        }

        
        public static void UndoRedoBranch(SelectedModel PopValue)
        { 
            ProductionManager.selectedGameObjects = new List<GameObject>{};
            GameObject Element = FindMatchingObjectID(PopValue.ObjectID);
            Debug.Log(Element);

            // Undo,Redoするとき対象のオブジェクトがなかったら
            if (Element == null) {
                GlobalVariables.ElementContent.transform.Find(PopValue.elementType).GetComponent<CreateElementButton>().CreateElement(PopValue.name);
                int ElementID = ProductionManager.selectedGameObjects[0].GetInstanceID();

                // undoStackのObjectIDの更新
                int StackCount = undoStack.Count;
                for(int i = 0; i < StackCount; i++){
                    SelectedModel SaveValue = undoStack.Pop();
                    if(SaveValue.ObjectID == PopValue.ObjectID){
                        SaveValue.ObjectID = ElementID;
                        
                    }
                    SaveStack.Push(SaveValue);
                }
                for(int i = 0; i < StackCount; i++)
                {
                    undoStack.Push(SaveStack.Pop());  
                }

                // redoStackのObjectIDの更新
                StackCount = redoStack.Count;
                for(int i = 0; i < StackCount; i++){
                    SelectedModel SaveValue = redoStack.Pop();
                    if(SaveValue.ObjectID == PopValue.ObjectID){
                        SaveValue.ObjectID = ElementID;
                    }
                    SaveStack.Push(SaveValue);
                }
                for(int i = 0; i < StackCount; i++)
                {
                    redoStack.Push(SaveStack.Pop());   
                }

                PopValue.ObjectID = ElementID;
                Element = FindMatchingObjectID(ElementID);

                AssignPopValue(PopValue, Element);
            }

            // 対象のオブジェクトがあったら
            else{
                switch (PopValue.tag)
                {

                    // オブジェクトを消去するUndoRedo
                    case "NowCreat" :
                        ProductionManager.selectedGameObjects = new List<GameObject> { Element };
                        DeleteElementButton InstanceDeleteElement = new DeleteElementButton();
                        InstanceDeleteElement.DestroyElement();
                        break;

                    // 名前を変える処理のUndo,Redo
                    case "ChangeName" :
                        ProductionManager.selectedGameObjects = new List<GameObject> { Element };
                        // 表示名の変更
                        GlobalVariables.content.transform.Find(ProductionManager.selectedGameObjects[0].transform.name).gameObject.GetComponent<ElementNamePrefab>().ChangeElementNameText(PopValue.name);
                        GlobalVariables.content.transform.Find(ProductionManager.selectedGameObjects[0].transform.name).transform.name = PopValue.name;
                        // オブジェクトの名前の変更
                        ProductionManager.selectedGameObjects[0].transform.name = PopValue.name;                        
                        break;

                    // UndoRedoで結合を解除する
                    case "MergeUndo" :
                        ProductionManager.selectedGameObjects = new List<GameObject> {};
                        for(int i = 0; i < PopValue.ObjectCount; i++){
                            SelectedModel popValue = undoStack.Pop();
                            GameObject MergeElement = FindMatchingObjectID(popValue.ObjectID);
                            ProductionManager.selectedGameObjects.Add(MergeElement);
                        }
                        ProductionFunction.UnMergeObjects();
                        break;

                    // UndoRedoで再結合させる
                    case "MergeRedo" :
                        ProductionManager.selectedGameObjects = new List<GameObject> {};
                        for(int i = 0; i < PopValue.ObjectCount; i++){
                            SelectedModel ChildObjectValue = undoStack.Pop();
                            GameObject ChiledElement = FindMatchingObjectID(PopValue.ObjectID);
                            ProductionManager.selectedGameObjects.Add(ChiledElement);
                            ProductionFunction.MergeObjects();
                        }
                        break;
                    
                    default :
                        AssignPopValue(PopValue, Element);
                        break;
                }
            }
            
        }

        // UndoRedoした時に保存していた値をオブジェクト代入
        public static void AssignPopValue(SelectedModel PopValue, GameObject Element)
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

        }    

        // instanceIDからオブジェクトを識別
        public static GameObject FindMatchingObjectID(int instanceID)
        {
            int index = ProductionManager.createdGameObjects.FindIndex(x => x.GetInstanceID() == instanceID);
            Debug.Log(index);
            return (ProductionManager.createdGameObjects[index]);
        }

        // Doした時にUndoStackに保存する値
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

        //オブジェクト生成されたときの処理
        public static void Create()
        {
            SelectedModel CreateValue =  NewModel(ProductionManager.selectedGameObjects[0]);
            CreateValue.tag = "NowCreat";
            CreateValue.Undotag = true;
            undoStack.Push(CreateValue);
            CreateValue = NewModel(ProductionManager.selectedGameObjects[0]);
            CreateValue.Undotag = false;
            undoStack.Push(CreateValue);
   
        }

        // オブジェクトが消去されたときの処理
        public static void Destroy()
        {
            Do(ProductionManager.selectedGameObjects[0]);
            SelectedModel DestroyValue = NewModel(ProductionManager.selectedGameObjects[0]);
            DestroyValue.tag = "NowCreat";
            undoStack.Push(DestroyValue);
        }

        // 名前が変更されたときの処理
        public static void ChangeName(bool Undotag = false)
        {
            SelectedModel NewNameValue = NewModel(ProductionManager.selectedGameObjects[0]);
            NewNameValue.Undotag = Undotag;
            NewNameValue.tag = "ChangeName";
            undoStack.Push(NewNameValue);
        }

        //オブジェクト結合されたときの処理
        public static void Merge()
        {
            SelectedModel MergeValue;
            int ChildCount = ProductionManager.selectedGameObjects[0].transform.childCount;  // 結合したオブジェクトの数を格納

            for (int i = 0; i <= ChildCount; i++){
                GameObject childObject = ProductionManager.selectedGameObjects[0].transform.GetChild(i).gameObject;
                MergeValue =  NewModel(childObject);
                MergeValue.ObjectCount = ChildCount;
                undoStack.Push(MergeValue);  
            }
            
            MergeValue = NewModel(ProductionManager.selectedGameObjects[0]);
            MergeValue.ObjectCount = ChildCount;
            MergeValue.tag = "MergeUndo";
            undoStack.Push(MergeValue);
            MergeValue.tag = "MergeRedo";
            undoStack.Push(MergeValue);
            redoStack.Clear();
        }

        // 結合が解除されたときの処理
        public static void UnMerge(GameObject UnMergeElement){
            SelectedModel UnMergeValue = NewModel(UnMergeElement);
            UnMergeValue.ChildObject = true;
            undoStack.Push(UnMergeValue);
        }
    }
}