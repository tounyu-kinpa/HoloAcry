using System.Collections.Generic;
using UnityEngine;
namespace Display.Production
{
    
    public class ProductionManager : MonoBehaviour
    {
        public static Mode CurrentMode = Mode.ChangeColor;

        public static List<GameObject> selectedGameObjects = new List<GameObject>();
        public static List<GameObject> createdGameObjects = new List<GameObject>();
        
        // Start is called before the first frame update
        void Start()
        {
            createdGameObjects.Add(GameObject.Find("Cylinder"));
            selectedGameObjects.Add(GameObject.Find("Cylinder"));
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
                var outline = createdGameObject.GetComponent<Outline>();
                
                if (selectedGameObjects.Exists(x => x == createdGameObject))
                {
                    if (outline != null)
                    {
                        outline.enabled = true;
                    }
                    else
                    {
                        AddOutlineComponent(createdGameObject);
                    }
                }
                else
                {
                    if (outline != null)
                    {
                        outline.enabled = false;
                    }
                }
            }
        }

        void AddOutlineComponent(GameObject gameObject)
        {
            var outline = gameObject.AddComponent<Outline>();
            outline.OutlineMode = Outline.Mode.OutlineAll;
            outline.OutlineColor = Color.red;
            outline.OutlineWidth = 5f;
        }
    }
}
