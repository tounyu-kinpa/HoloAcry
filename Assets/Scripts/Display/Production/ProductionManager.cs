using System.Collections.Generic;
using UnityEngine;
namespace Display.Production
{
    
    public class ProductionManager : MonoBehaviour
    {
        public static Mode CurrentMode = Mode.ChangeColor;

        public static List<GameObject> selectedGameObjects = new List<GameObject>();
        public static List<GameObject> createdGameObjects = new List<GameObject>();

        public Material material;
        
        // Start is called before the first frame update
        void Start()
        {
            createdGameObjects.Add(GameObject.Find("Cube"));
            selectedGameObjects.Add(GameObject.Find("Cube"));
        }

        // Update is called once per frame
        void Update()
        {
            
            if (selectedGameObjects == null)
            {
            }
            else
            {
                //ProductionFunction.ChangePos(selectedGameObjects[0]);
                //ProductionFunction.ChangeScale(selectedGameObjects[0]);
            }
            
            //ProductionFunction.MoveCamera();
            //ProductionFunction.RotateCamera();
            ProductionFunction.ChangeSlope(0.5f);
            
            //選択されているオブジェクトにアウトラインを適用する処理
            foreach (var createdGameObject in createdGameObjects)
            {
                
                if (selectedGameObjects.Exists(x => x == createdGameObject))
                {
                    createdGameObject.GetComponent<MeshRenderer>().material = material;
                }
                else
                {
                    createdGameObject.GetComponent<MeshRenderer>().material = default;
                }
            }
        }
    }
}
