using Display.Production;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UIElements;

public class Camera4Move : MonoBehaviour
{
    public GameObject camera4;

    private float camera4X = 0;
    private float camera4Y = 125;
    private float camera4Z = 0;

    public GameObject ListUI;
    public GameObject Panel;

    // Update is called once per frame
    void Update()
    {
        Debug.Log(ProductionManager.selectedGameObjects);
        //オブジェクト選択中の場合
        if((ListUI.activeSelf) && (ProductionManager.selectedGameObjects != null))
        {
            //4つのカメラの移動位置
            camera4X = (GlobalVariables.workNumber % 2) == 0 ? 125.0f : 0.0f;
            camera4Y = (GlobalVariables.workNumber % 2) == 0 ? camera4Y : camera4Y - 125.0f;
            OnClick();
        }           
    }

    public void OnClick()
    {
        //カメラの位置移動とアクティブ
        camera4.transform.position = new Vector3(camera4X, camera4Y, camera4Z);
        camera4.SetActive(true);
    }
}
