using System.Collections;
using System.Collections.Generic;
using Display.Production;
using UnityEngine;

public class RayDebug : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera camera;
    void Start()
    {
    }

    private void Update () {

        if (Input.touchCount == 1)
        {
            //ダブルタッチ判定
            if (Input.touches[0].phase == TouchPhase.Began && Input.touches[0].tapCount == 2)
            {
                //メインカメラ上のマウスカーソルのある位置からRayを飛ばす
                Ray ray = camera.ScreenPointToRay(Input.touches[0].position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit)){
                    //Rayが当たるオブジェクトがあった場合はそのオブジェクトをProductionManager.selectedGameObjectsに追加
                    if (ProductionManager.selectedGameObjects.Exists(x => x == hit.collider.gameObject))
                    {
                        ProductionManager.selectedGameObjects.Remove(hit.collider.gameObject);
                    }
                    else
                    {
                        ProductionManager.selectedGameObjects.Add(hit.collider.gameObject);
                    }

            
                    // if (hit.collider.gameObject.transform.parent == GlobalVariables.content)
                    // {
                    //     var obj = GlobalVariables.CurrentWork.transform.Find(hit.collider.gameObject.transform.name);
                    //     ProductionManager.selectedGameObjects.Add(obj.gameObject);
                    // }
                }
                else
                {
                    //そうでない場合ProductionManager.selectedGameObjectsの全要素を削除
                    ProductionManager.selectedGameObjects.Clear();
                }

            }
        }

    }

}
