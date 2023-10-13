using Display.Production;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UIElements;

public class Camera4Move : MonoBehaviour
{
    public GameObject Main_Camera;

    public GameObject Black_Camera;
    public GameObject camera4;

    private float camera4X = 0;
    private float camera4Y = 0;
    private float camera4Z = 10;

    public GameObject ListUI;
    public GameObject Panel;

    // Update is called once per frame
    void Update()
    {
        //�I�u�W�F�N�g�I�𒆂̏ꍇ
        if((ListUI.activeSelf) && (ProductionManager.selectedGameObjects.Count != 0))
        {
            //4�̃J�����̈ړ��ʒu
            camera4X = (GlobalVariables.workNumber % 2) == 0 ? 125.0f : 0.0f;
            camera4Y = (GlobalVariables.workNumber % 2) == 0 ? camera4Y : camera4Y - 125.0f;
            OnClick();
        }           
    }

    public void OnClick()
    {
        Debug.Log(aa)
        Main_Camera.SetActive(false);
        Black_Camera.SetActive(true);
        //�J�����̈ʒu�ړ��ƃA�N�e�B�u
        camera4.transform.position = new Vector3(camera4X, camera4Y, camera4Z);
        camera4.SetActive(true);
    }
}
