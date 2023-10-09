using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadController : MonoBehaviour
{
    public GameObject WorkSpace;

    public GameObject Cube;           // 四角柱
    public GameObject Ball;           // 球
    public GameObject Cylinder;       // 円柱
    public GameObject SquarePyramid;  // 三角錐
    public GameObject Cone;           // 円錐

    public void LoadWorks()
    {
        string WorksData = File.ReadAllText(GlobalVariables.SaveFilePath);
        Model LoadedData = JsonUtility.FromJson<Model>(WorksData);

        foreach (var work in LoadedData.works)
        {
            GlobalVariables.workNumber++;
            
            GameObject createdWork = Instantiate(WorkSpace);

            createdWork.transform.name = work.work_name;

            InstantiateElements(createdWork, work.elements);
        }
    }

    // 作品内のElementsを引数として受け取ったWorkの子オブジェクトとして生成する関数
    public void InstantiateElements(GameObject createdWork , List<Element> elements)
    {
        GameObject Instance = null;

        foreach (var element in elements)
        {
            switch (element.elementType)
            {
                case "Cube":
                    Instance = Instantiate(Cube, createdWork.transform);
                    break;
                    
                case "Ball":
                    Instance = Instantiate(Ball, createdWork.transform);
                    break;

                case "Cylinder":
                    Instance = Instantiate(Cylinder, createdWork.transform);
                    break;

                case "SquarePyramid":
                    Instance = Instantiate(SquarePyramid, createdWork.transform);
                    break;

                case "Cone":
                    Instance = Instantiate(Cone, createdWork.transform);
                    break;
            }

            if(Instance != null)
            {
                // 必要なコンポーネントの取得
                Renderer InstanceColor        = Instance.GetComponent<Renderer>();
                MeshFilter InstanceMeshFilter = Instance.GetComponent<MeshFilter>();
                
                // 各種値を設定
                Instance.transform.name             = element.name;
                Instance.transform.localScale       = element.scale;
                Instance.transform.localPosition    = element.position;
                Instance.transform.localEulerAngles = element.rotate;
                InstanceMeshFilter.mesh.vertices    = element.meshVertices;
                InstanceColor.material.color        = element.color;
            }
        }
    }
}