using System.Collections.Generic;
using UnityEngine;

namespace Display.Production
{
    public class ProductionFunction
    {
        private static float beforeDis = -1f;
        private static Vector3 beforeScale = Vector3.one;

        private static float _beforeDis = -1f;
        
        private static GameObject MainCamera = GameObject.Find("Main Camera");

        public static void ChangeScale(GameObject gameObject)
        {
            if (Input.touchCount == 2)
            {
                if (beforeDis > 0)
                {
                    var dis = Vector2.Distance(Input.touches[0].position, Input.touches[1].position);
                    var scale = beforeScale * (dis / beforeDis);
                    gameObject.transform.localScale = scale;
                }
                else
                {
                    beforeDis = Vector2.Distance(Input.touches[0].position, Input.touches[1].position);
                }
            }

            if (Input.touchCount < 1 && beforeDis > 0)
            {
                beforeDis = -1f;
                beforeScale = gameObject.transform.localScale;
            }

            UndoRedo.Do();
        }

        public static void ChangePos(GameObject gameObject)
        {
            //前フレームからの指の移動量を取得し、その分だけオブジェクトを移動させる
            if (Input.touchCount == 1)
            {
                var x = MainCamera.transform.right;
                var y = MainCamera.transform.up;
                
                var deltapos = Input.touches[0].deltaPosition;
                
                gameObject.transform.Translate(x * deltapos.x * 0.1f * Time.deltaTime);
                gameObject.transform.Translate(y * deltapos.y * 0.1f * Time.deltaTime);

            }

        }

        public static void MoveCamera()
        {
            if (Input.touchCount == 2)
            {
                var transform = MainCamera.transform;
                var x = MainCamera.transform.right;
                var y = MainCamera.transform.up;
                    
                var deltapos = Input.touches[0].deltaPosition;
                    
                transform.position += -x * deltapos.x * 0.1f * Time.deltaTime;
                transform.position += -y * deltapos.y * 0.1f * Time.deltaTime;
            }

        }

        public static void RotateCamera()
        {
            if (Input.touchCount == 1)
            {
                var x = MainCamera.transform.right;
                var y = MainCamera.transform.up;
                    
                var deltapos = Input.touches[0].deltaPosition;
                    
                MainCamera.transform.RotateAround(MainCamera.transform.position, Vector3.up, deltapos.x * 2 * Time.deltaTime);
                MainCamera.transform.RotateAround(MainCamera.transform.position, MainCamera.transform.right, -deltapos.y * 2 * Time.deltaTime);

            }
        }
        
        public static void ChangeCameraScale()
        {
            if (Input.touchCount == 2)
            {
                if (_beforeDis > 0)
                {
                    var dis = Vector2.Distance(Input.touches[0].position, Input.touches[1].position);
                    var delta = dis - _beforeDis;
                    MainCamera.transform.position += MainCamera.transform.forward * delta * 0.7f;
                    _beforeDis = -1f;
                }
                else
                {
                    _beforeDis = Vector2.Distance(Input.touches[0].position, Input.touches[1].position);
                }
            }

            if (Input.touchCount < 1 && _beforeDis > 0)
            {
                _beforeDis = -1f;
            }

        }


        public static void ChangeColorRGB(Color32 color)
        {
            foreach (var selectedGameObject in ProductionManager.selectedGameObjects)
            {
                MeshRenderer mesh = selectedGameObject.GetComponent<MeshRenderer>();
                mesh.material.color = color;
            }
        }

        public static void ChangeColorHSV(float h, float s, float v)
        {
            foreach (var selectedGameObject in ProductionManager.selectedGameObjects)
            {
                MeshRenderer mesh = selectedGameObject.GetComponent<MeshRenderer>();
                mesh.material.color = Color.HSVToRGB(90, 63, 50);
            }

        }

        public static void MergeObjects()
        {
            var flag = true;
            GameObject MergedObjects = null;
            
            foreach (var selectedGameObject in ProductionManager.selectedGameObjects)
            {
                //初回だけ新規オブジェクト作成
                if (flag)
                {
                    MergedObjects = new GameObject();
                    ProductionManager.createdGameObjects.Add(MergedObjects);
                    flag = false;
                }

                selectedGameObject.transform.parent = MergedObjects.transform;

            }

        }
        
        public static void UnMergeObjects()
        {
            foreach (var selectedGameObject in ProductionManager.selectedGameObjects)
            {
                selectedGameObject.transform.parent = null;
            }

        }


        public static void ChangeSlope()
        {
            foreach (var selectedGameObject in ProductionManager.selectedGameObjects)
            {
                Mesh mesh = selectedGameObject.GetComponent<MeshFilter>().mesh;
                Vector3[] vertices = mesh.vertices;
                
                for (int i = 0; i < vertices.Length; i++)
                {
                    if (vertices[i].y == 1.0f)
                    {
                        vertices[i] = Vector3.Lerp(vertices[i], vertices[41], 0.5f);
                    }
                }

                mesh.vertices = vertices;
            }

        }

        public static void ChangeRotation(float x, float y, float z)
        {
            foreach (var selectedGameObject in ProductionManager.selectedGameObjects)
            {
                selectedGameObject.transform.rotation = Quaternion.Euler(x, y, z);
            }

        }

        public static void ApplyBooleanOp()
        {
            foreach (var selectedGameObject in ProductionManager.selectedGameObjects)
            {
            }

        }
    }

}