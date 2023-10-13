using System.Collections.Generic;
using UnityEngine;
using Parabox.CSG;

namespace Display.Production
{
    public class ProductionFunction : MonoBehaviour
    {
        private static float beforeDis = -1f;
        private static Vector3 beforeScale = Vector3.one;

        private static float _beforeDis = -1f;

        private static int Objectnamecounter = 1;
        
        private static GameObject MainCamera = GameObject.Find("Main Camera");
        
        public static void ChangeScale()
        {
                if (Input.touchCount == 2)
                {
                    if (beforeDis > 0)
                    {
                        var dis = Vector2.Distance(Input.touches[0].position, Input.touches[1].position);
                        var delta = dis - beforeDis;
                        
                        foreach (var selectedGameObject in ProductionManager.selectedGameObjects)
                        {
                            selectedGameObject.transform.localScale += new Vector3(delta, delta, delta) * 0.01f;
                        }
                        beforeDis = -1f;
                    }
                    else
                    {
                        beforeDis = Vector2.Distance(Input.touches[0].position, Input.touches[1].position);
                    }
                }

                if (Input.touchCount < 2 && beforeDis > 0)
                {
                    beforeDis = -1f;
                }
                
        }

        public static void ChangePos()
        {
            foreach (var selectedGameObject in ProductionManager.selectedGameObjects)
            {
                //前フレームからの指の移動量を取得し、その分だけオブジェクトを移動させる
                if (Input.touchCount == 1)
                {
                    var x = MainCamera.transform.right;
                    var y = MainCamera.transform.up;
                    
                    var deltapos = Input.touches[0].deltaPosition;
                    
                    selectedGameObject.transform.Translate(x * (deltapos.x * 0.1f * Time.deltaTime));
                    selectedGameObject.transform.Translate(y * (deltapos.y * 0.1f * Time.deltaTime));

                }
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
                    
                MainCamera.transform.RotateAround(MainCamera.transform.position, Vector3.up, deltapos.x * Time.deltaTime);
                MainCamera.transform.RotateAround(MainCamera.transform.position, MainCamera.transform.right, -deltapos.y * Time.deltaTime);

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
                    MainCamera.transform.position += MainCamera.transform.forward * (delta * 0.02f);
                    _beforeDis = Vector2.Distance(Input.touches[0].position, Input.touches[1].position);
                }
                else
                {
                    _beforeDis = Vector2.Distance(Input.touches[0].position, Input.touches[1].position);
                }

            }

            if (Input.touchCount < 2 && _beforeDis > 0)
            {
                _beforeDis = -1f;
            }

        }

        public static void Camera()
        {
            if (Input.touchCount == 2)
            {
                //MoveCamera
                var transform = MainCamera.transform;
                var x = MainCamera.transform.right;
                var y = MainCamera.transform.up;
                    
                //var deltapos = Deltapositionperframe(Input.touches[0]);
                var deltapos = Input.touches[0].deltaPosition;

                var position = transform.position;
                position += -x * (deltapos.x * 0.2f * Time.deltaTime);
                position += -y * (deltapos.y * 0.2f * Time.deltaTime);
                transform.position = position;

                //ChangeCameraScale
                if (_beforeDis > 0)
                {
                    var dis = Vector2.Distance(Input.touches[0].position, Input.touches[1].position);
                    var delta = dis - _beforeDis;
                    MainCamera.transform.position += MainCamera.transform.forward * (delta * 0.02f);
                    _beforeDis = Vector2.Distance(Input.touches[0].position, Input.touches[1].position);
                }
                else
                {
                    _beforeDis = Vector2.Distance(Input.touches[0].position, Input.touches[1].position);
                }
            }
            
            if (Input.touchCount < 2 && _beforeDis > 0)
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
                //初回だけ
                if (flag)
                {
                    //新規オブジェクト作成
                    MergedObjects = new GameObject();
                    
                    //createdGameObjectsに新規オブジェクトを追加
                    ProductionManager.createdGameObjects.Add(MergedObjects);
                    
                    //新規オブジェクトの名前を変更
                    MergedObjects.name = "結合体" + Objectnamecounter;
                    
                    //新規オブジェクトにつける名前の数字をインクリメント
                    Objectnamecounter++;
                    
                    flag = false;
                }
                
                selectedGameObject.transform.parent = MergedObjects.transform;

            }

        }
        
        public static void UnMergeObjects()
        {
            var flag = true;
            
            foreach (var selectedGameObject in ProductionManager.selectedGameObjects)
            {
                if (flag)
                {
                    Destroy(selectedGameObject.transform.parent.gameObject);
                    flag = false;
                }
                selectedGameObject.transform.parent = null;
            }

        }

        public static void ApplyBooleanOp()
        {
            Parabox.CSG.Model result = CSG.Subtract(ProductionManager.selectedGameObjects[0],
                ProductionManager.selectedGameObjects[1]);

            //元のオブジェクトの色を取得
            MeshRenderer mesh = ProductionManager.selectedGameObjects[0].GetComponent<MeshRenderer>();
            var color = mesh.material.color;
            
            //新しくオブジェクト生成
            var composite = new GameObject();
            
            //新しく生成したオブジェクトの位置を切り取り前のオブジェクトの位置に設定
            composite.transform.position = ProductionManager.selectedGameObjects[0].transform.position;
            
            composite.AddComponent<MeshFilter>().sharedMesh = result.mesh;
            composite.AddComponent<MeshRenderer>().sharedMaterials = result.materials.ToArray();

            //mesh = composite.GetComponent<MeshRenderer>();
            //mesh.material.color = color;
            
            ProductionManager.selectedGameObjects.Add(composite);
        }
        
        public static void ChangeScaleByUI(float x, float y, float z)
        {
            foreach (var selectedGameObject in ProductionManager.selectedGameObjects)
            {
                selectedGameObject.transform.localScale = new Vector3(x, y, z);
            }
        }

        public static void ChangeSlope(float t)
        {
            foreach (var selectedGameObject in ProductionManager.selectedGameObjects)
            {
                Mesh mesh = selectedGameObject.GetComponent<MeshFilter>().mesh;
                Vector3[] vertices = mesh.vertices;
                Vector3 centerVertex = default;

                
                for (int i = 0; i < vertices.Length; i++)
                {
                    if (vertices[i].y >= 0)
                    {
                        centerVertex = new Vector3(0, vertices[i].y, 0);
                        break;
                    }
                }
                
                for (int i = 0; i < vertices.Length; i++)
                {
                    if (vertices[i].y >= 0)
                    {
                        vertices[i] = Vector3.Lerp(vertices[i], centerVertex, t);
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


        public static Vector2 Deltapositionperframe(Touch touch)
        {
            var moveDist = (touch.deltaPosition / touch.deltaTime) * Time.deltaTime;
            return moveDist;
        }
    }

}