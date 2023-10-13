using System.Collections.Generic;
using UnityEngine;

namespace Display.Production
{
    
    public class ProductionManager : MonoBehaviour
    {
        public static Mode CurrentMode = Mode.ChangeColor;

        public static List<GameObject> selectedGameObjects = new List<GameObject>();
        public static List<GameObject> createdGameObjects = new List<GameObject>();

        public Material Default_material;
        
        // Start is called before the first frame update
        void Start()
        {
            createdGameObjects.Add(GameObject.Find("Cube"));
            
            foreach (var createdGameObject in createdGameObjects)
            {
                var outline = createdGameObject.AddComponent<Outline>();
                outline.OutlineMode = Outline.Mode.OutlineAll;
                outline.OutlineColor =Color.red;
                outline.OutlineWidth = 5f;

            }
        }

        void Update()
        {
            
            if (selectedGameObjects.Count == 0)
            {
                ProductionFunction.Camera();
                //ProductionFunction.ChangeCameraScale();
            }

            else
            {
                ProductionFunction.MoveCamera();
                ProductionFunction.RotateCamera();
            }
            
            //選択されているオブジェクトにアウトラインを適用する処理
            foreach (var createdGameObject in createdGameObjects)
            {
                var outline = createdGameObject.GetComponent<Outline>();
                
                if (selectedGameObjects.Exists(x => x == createdGameObject))
                {
                    outline.OutlineMode = Outline.Mode.OutlineAll;
                }
                else
                {
                    outline.OutlineMode = Outline.Mode.OutlineHidden;
                }
            }
        }
    }
}
