using System.Collections.Generic;
using UnityEngine;

namespace Display.Production
{
    
    public class ProductionManager : MonoBehaviour
    {
        public static Mode CurrentMode = Mode.ChangeColor;

        public static List<GameObject> selectedGameObjects = new List<GameObject>();
        public static List<GameObject> createdGameObjects = new List<GameObject>();
        
        [SerializeField] Material Outline_material;
        [SerializeField] private Material Default_material;
        
        // Start is called before the first frame update
        void Start()
        {
            
            foreach (var createdGameObject in createdGameObjects)
            {

            }
        }

        void Update()
        {
            
            if (GlobalVariables.isUIEventHandled == false)
            {
                if (selectedGameObjects.Count == 0)
                {
                    ProductionFunction.Camera();
                    ProductionFunction.RotateCamera();
                }
                else
                {
                    ProductionFunction.ChangeScale();
                    ProductionFunction.ChangePos();
                }
            
            }
            
            //選択されているオブジェクトにアウトラインを適用する処理
            foreach (var createdGameObject in createdGameObjects)
            {
                var meshRenderer = createdGameObject.GetComponent<MeshRenderer>();
                var color = meshRenderer.material.color;
                
                if (selectedGameObjects.Exists(x => x == createdGameObject))
                {
                    meshRenderer.material = Outline_material;
                    meshRenderer.material.color = color;
                }
                else
                {
                    meshRenderer.material = Default_material;
                    meshRenderer.material.color = color;
                }
            }
        }
    }
}