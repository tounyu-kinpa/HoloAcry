using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class ProductionFunction
    {
        private static float beforeDis = -1f;
        private static Vector3 beforeScale = Vector3.one;
        private static bool flag = true;

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

        }

        public static void ChangePos(GameObject gameObject)
        {
            //前フレームからの指の移動量を取得し、その分だけオブジェクトを移動させる
            if (Input.touchCount == 1)
            {
                var n = MainCamera.transform.forward;
                var dis = Input.touches[0].deltaPosition.magnitude;

            }

        }

        public static void ChangeColor(List<GameObject> gameObjects, Color32 color)
        {
            MeshRenderer mesh;
            mesh = gameObjects[0].GetComponent<MeshRenderer>();
            mesh.material.color = color;
        }

        public static void MergeObjects(GameObject[] gameObjects)
        {
            GameObject MergedObjects = new GameObject();

            foreach (var gameObject in gameObjects)
            {
                gameObject.transform.parent = MergedObjects.transform;

            }
        }

        public static void ChangeSlope(GameObject gameObject)
        {
            Mesh mesh = gameObject.GetComponent<MeshFilter>().mesh;
            Vector3[] vertices = mesh.vertices;
            
            for (int i = 0; i < vertices.Length; i++)
            {
                if (vertices[i].y == 1.0f)
                {
                    vertices[i] = Vector3.Lerp(vertices[i], vertices[41], 0.5f);
                }
                Debug.Log($"{vertices[i]} {i}");
            }

            mesh.vertices = vertices;
        }

        public static void ChangeRotation(GameObject gameObject, float x, float y, float z)
        {
            gameObject.transform.rotation = Quaternion.Euler(x, y, z);
        }

        public static void ApplyBooleanOp(List<GameObject> gameObjects)
        {
            gameObjects[0].AddComponent<ChangePOV>();
        }
    }

}