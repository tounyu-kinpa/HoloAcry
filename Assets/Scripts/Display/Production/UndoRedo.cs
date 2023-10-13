using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
        private static int n = 0;   // UnMergeのとき親の値をstackに入れるときの変数
        public static SelectedModel ParentValue;
        public Button UndoButton;
        public Button RedoButton;

        void Stert()
        {
            UndoButton = GetComponent<Button>();
            RedoButton = GetComponent<Button>();

        }

        void Update()
        {
            if(undoStack.Count < 2){
                UndoButton.interactable = false;
            }
            else{
                UndoButton.interactable = true;
            }
        
            if(redoStack.Count == 0){
                RedoButton.interactable = false;
            }
            else{
                RedoButton.interactable = true;
            }

        }
        
        public static void Undo()
        {
            if(undoStack.Count >= 2){
            
                SelectedModel UndoValue = undoStack.Pop();

                // UndotagがtrueならredoStackにPush
                if (UndoValue.Undotag == true){
                    // 結合したオブジェクト分redostack.Pushする処理
                    if (UndoValue.tag == "UnMerge" || UndoValue.tag == "ReMerge"){
                        for (int i = 0; i < 2 ; i++){
                        
                            SelectedModel undoChildVale = undoStack.Pop();
                            redoStack.Push(undoChildVale);
                        }
                    }
                    else{
                        redoStack.Push(UndoValue);
                    }
                    UndoValue = undoStack.Pop();
                    
                }
                redoStack.Push(UndoValue);
                UndoValue = undoStack.Pop();

                UndoRedoBranch (UndoValue);
            }    

        }

        public static void Redo()
        {

            // Stackから取り出して代入する関数
            SelectedModel RedoValue = redoStack.Pop();
            
            // 結合したオブジェクト分undo.Pushする処理
            if (RedoValue.ChildObject == true){

                undoStack.Push(RedoValue);

                for (int i = 0; i < 2 ; i++){

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
            // undoStack.Push(RedoValue);
        }
  


        // どんな変更をUndoRedoするのかの処理
        public static void UndoRedoBranch(SelectedModel PopValue)
        { 

            ProductionManager.selectedGameObjects = new List<GameObject>{};
            int Index = FindMatchingObjectID(PopValue.ObjectID);        // selectのオブジェクトのcreatGameObjectsのインデックスを格納
            GameObject Element; // 取得したインデックスのcreatGameObjectsを格納


            // UndoRedoするとき対象のオブジェクトがなかったら
            if (Index < 0){
                // 保存した名前を渡してオブジェクトを生成
                GlobalVariables.ElementContent.transform.Find(PopValue.elementType).GetComponent<CreateElementButton>().CreateElement(PopValue.name);

                // undoStackのObjectIDの更新
                CreateUpdateID(PopValue, ProductionManager.selectedGameObjects[0]);
                undoStack.Push(PopValue);
            }

            // 対象のオブジェクトがあったら
            else{
                
                Element = ProductionManager.createdGameObjects[Index];

                switch (PopValue.tag)
                {

                    // オブジェクトを消去するUndoRedo
                    case "NowCreat" :
                        ProductionManager.selectedGameObjects = new List<GameObject> { Element };
                        
                        DeleteElementButton InstanceDeleteElement = new DeleteElementButton();
                        InstanceDeleteElement.DestroyElement();

                        undoStack.Push(PopValue);

                        break;

                    // 名前を変える処理のUndoRedo
                    case "ChangeName" :
                        ProductionManager.selectedGameObjects = new List<GameObject> { Element };

                        // 表示名の変更
                        GlobalVariables.content.transform.Find(ProductionManager.selectedGameObjects[0].transform.name).gameObject.GetComponent<ElementNamePrefab>().ChangeElementNameText(PopValue.name);
                        GlobalVariables.content.transform.Find(ProductionManager.selectedGameObjects[0].transform.name).transform.name = PopValue.name;

                        // オブジェクトの名前の変更
                        ProductionManager.selectedGameObjects[0].transform.name = PopValue.name;  

                        undoStack.Push(PopValue);

                        break;

                    // 結合を解除する
                    case "UnMerge" :
                        SelectedModel UnMergeParentPopValue = null; // Undotag = trueの場合undoStackにある親の値を格納
                        SelectedModel ChildpopValue;    // undoStackにある子オブジェクトの値を格納
                        ProductionManager.selectedGameObjects = new List<GameObject> {};

                        if(PopValue.Undotag != true){
                            UnMergeParentPopValue = undoStack.Pop();
                        }
                        for(int i = 0; i < 2; i++){
                                ChildpopValue = undoStack.Pop();

                                Index = FindMatchingObjectID(ChildpopValue.ObjectID);
                                GameObject MergeElement = ProductionManager.createdGameObjects[Index];

                                ProductionManager.selectedGameObjects.Add(MergeElement);
                            }

                        ProductionFunction.UnMergeObjects();

                        // undoStackに入った親の値を、値を更新するため取り出す
                        SelectedModel DestroyPopValue = undoStack.Pop();

                        // 正しい親の値をPush
                        if(PopValue.Undotag != true){
                            undoStack.Push(UnMergeParentPopValue);
                            undoStack.Push(PopValue);
                        }
                        else{
                            undoStack.Push(PopValue);
                        }
                        break;
                        
                    // 再結合する
                    case "ReMerge" :
                        SelectedModel ReMergeParentPopValue = null;
                        SelectedModel popValue;
                        ProductionManager.selectedGameObjects = new List<GameObject> {};

                        if(PopValue.Undotag != true){
                            ReMergeParentPopValue = undoStack.Pop();
                        }

                        for(int i = 0; i < 2; i++){
                            popValue = undoStack.Pop();

                            Index = FindMatchingObjectID(popValue.ObjectID);
                            GameObject ChiledElement = ProductionManager.createdGameObjects[Index];

                            ProductionManager.selectedGameObjects.Add(ChiledElement);
                            
                        }
                        
                        ProductionFunction.MergeObjects();

                        if(PopValue.Undotag != true){
                            undoStack.Push(ReMergeParentPopValue);
                            undoStack.Push(PopValue);
                        }
                        else{
                            undoStack.Push(PopValue);
                        }

                        CreateUpdateID(PopValue, ProductionManager.selectedGameObjects[0]);
                        break;
                    
                    default :

                        AssignPopValue(PopValue, Element);
                        undoStack.Push(PopValue);
                        break;

                }
            }
            
        }


        // instanceIDからオブジェクトを識別してインデックスを返す
        public static int FindMatchingObjectID(int instanceID)
        {
            int index = ProductionManager.createdGameObjects.FindIndex(x => x.GetInstanceID() == instanceID);
            return (index);
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

        
        public static void Do(GameObject SelectedObject, bool Undotag = false)
        {
            undoStackCheck();
            redoStack.Clear();

            SelectedModel DoValue =  NewModel(SelectedObject); 
            DoValue.Undotag = Undotag;

            // 変更後のObjectの値をまとめてUndoStackにPush
            undoStack.Push(DoValue);
            Debug.Log("Do = " + undoStack.Count);

        }

        //オブジェクト生成されたときの処理
        public static void Create()
        {
            undoStackCheck();
            redoStack.Clear();
            
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
            
            Do(ProductionManager.selectedGameObjects[0], true);

            SelectedModel DestroyValue = NewModel(ProductionManager.selectedGameObjects[0]);

            DestroyValue.tag = "NowCreat";
            undoStack.Push(DestroyValue);

        }

        // 名前が変更されたときの処理
        public static void ChangeName(bool Undotag = false)
        {

            if(Undotag == true){
                undoStackCheck();
                redoStack.Clear();
            }

            SelectedModel NewNameValue = NewModel(ProductionManager.selectedGameObjects[0]);

            NewNameValue.Undotag = Undotag;
            NewNameValue.tag = "ChangeName";

            undoStack.Push(NewNameValue);

        }

        //オブジェクト結合されたときの処理
        public static void Merge(GameObject MergeObject)
        {
            undoStackCheck();
            SelectedModel MergeValue;

            n++;
            switch (n)
            {
                case 1 : 
                    undoStackCheck();
                    ParentValue = NewModel(MergeObject);
                    ParentValue.tag = "UnMerge";
                    ParentValue.Undotag = true;

                    break;

                case 2 :
                    MergeValue = NewModel(MergeObject);
                    MergeValue.ChildObject = true;
                    undoStack.Push(MergeValue);

                    break;

                case 3 :
                    MergeValue = NewModel(MergeObject);
                    MergeValue.ChildObject = true;
                    undoStack.Push(MergeValue);

                    undoStack.Push(ParentValue);

                    int index = FindMatchingObjectID(ParentValue.ObjectID);
                    GameObject RedoMergeObject = ProductionManager.createdGameObjects[index];
                    ParentValue = NewModel(RedoMergeObject);
                    ParentValue.tag = "ReMerge";
                    redoStack.Push(ParentValue);
                    n = 0;

                    break;

                
                default:
                    Debug.Log("nは間違った値");

                    break;
            }

            // for (int i = 0; i <= 2; i++){
            //     GameObject childObject = ProductionManager.selectedGameObjects[0].transform.GetChild(i).gameObject;
            //     MergeValue =  NewModel(childObject);
                
            //     MergeValue.ChildObject = true;
            //     undoStack.Push(MergeValue);  
            // }
            
            // MergeValue = NewModel(ProductionManager.selectedGameObjects[0]);
            // MergeValue.tag = "Merge";
            // MergeValue.Undotag = true;
            // undoStack.Push(MergeValue);

            // MergeValue = NewModel(ProductionManager.selectedGameObjects[0]);
            // MergeValue.tag = "Merge";
            // undoStack.Push(MergeValue);

        }

        // 結合が解除されたときの処理
        public static void UnMerge(GameObject UnMergeElement)// 引数にUnMergeObjectsのselectedGameObject
        { 
            n++;
            switch (n)
            {
                case 1 : 
                    undoStackCheck();
                    ParentValue = NewModel(UnMergeElement);
                    ParentValue.tag = "ReMerge";
                    ParentValue.Undotag = true;

                    break;

                case 2 :
                    SelectedModel UnMergeValue = NewModel(UnMergeElement);
                    UnMergeValue.ChildObject = true;
                    undoStack.Push(UnMergeValue);

                    break;

                case 3 :
                    UnMergeValue = NewModel(UnMergeElement);
                    UnMergeValue.ChildObject = true;
                    undoStack.Push(UnMergeValue);

                    undoStack.Push(ParentValue);

                    int index = FindMatchingObjectID(ParentValue.ObjectID);
                    GameObject RedoUnMergeObject = ProductionManager.createdGameObjects[index];
                    ParentValue = NewModel(RedoUnMergeObject);
                    ParentValue.tag = "UnMerge";
                    redoStack.Push(ParentValue);
                    n = 0;

                    break;

                
                default:
                    Debug.Log("nは間違った値");

                    break;

            }
        }

        public static void CreateUpdateID(SelectedModel PopValue, GameObject creatObject)
        {
            int UpdateID = creatObject.GetInstanceID();

            // undoStackのObjectIDの更新
            int StackCount = undoStack.Count;
            for(int i = 0; i < StackCount; i++){
                SelectedModel SaveValue = undoStack.Pop();
                if(SaveValue.ObjectID == PopValue.ObjectID){
                    SaveValue.ObjectID = UpdateID;
                    
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
                    SaveValue.ObjectID = UpdateID;
                }
                SaveStack.Push(SaveValue);
            }

            for(int i = 0; i < StackCount; i++)
            {
                redoStack.Push(SaveStack.Pop());   
            }

            PopValue.ObjectID = UpdateID;
            int index = FindMatchingObjectID(UpdateID);
            GameObject Element = ProductionManager.createdGameObjects[index];
            

            AssignPopValue(PopValue, Element);

        }

        public static void undoStackCheck()
        {
            if(undoStack.Count > 0){
                SelectedModel CheckUndoValue = undoStack.Pop();

                if(CheckUndoValue.Undotag != true){
                    undoStack.Push(CheckUndoValue);
                }
            }


        }
        
    }
}