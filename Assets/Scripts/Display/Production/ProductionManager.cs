using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Display.Production
{
    
    public class ProductionManager : MonoBehaviour
    {
        public static Mode CurrentMode = Mode.ChangeColor;

        public static List<GameObject> selectedGameObjects = new List<GameObject>();
        public static List<GameObject> createdGameObjects = new List<GameObject>();

        public Material OutlineMaterial;
        
        // Start is called before the first frame update
        void Start()
        {
            createdGameObjects.Add(GameObject.Find("Cube"));
            //selectedGameObjects.Add(GameObject.Find("Cube"));
        }

        // Update is called once per frame
        void Update()
        {
            
            if (selectedGameObjects == null)
            {
            }
            else
            {
                

            }
            //ProductionFunction.ChangePos(selectedGameObjects[0]);
            //ProductionFunction.ChangeScale(selectedGameObjects[0]);
            ProductionFunction.MoveCamera();
            ProductionFunction.RotateCamera();
            ProductionFunction.ChangeCameraScale();

            foreach (var createdGameObject in createdGameObjects)
            {
                if (selectedGameObjects.Exists(x => x == createdGameObject))
                {
                    ApplyOutline(createdGameObject);
                }
                else
                {
                    RemoveOutline(createdGameObject); 
                }
            }
        }

        void ApplyOutline(GameObject gameObject)
        {
            gameObject.AddComponent<Outline>();
        }

        void RemoveOutline(GameObject gameObject)
        {
            Destroy(gameObject.GetComponent<Outline>());
        }
    }
}
