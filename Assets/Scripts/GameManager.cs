using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Mode CurrentMode = Mode.ChangeColor;

    public static GameObject selectedGameObject;
    public static GameObject CurrentWork;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (selectedGameObject == null)
        {
            switch (Input.touchCount)
            {
                case 1:
                    //視点移動();
                    break;
                case 2:
                    //カメラ位置移動();
                    break;
            }
        }
        else
        {
            switch (Input.touchCount)
            {
                case 1:
                    //BaseProduction.ChangePos(selectedGameObject);
                    break;
                case 2:
                    //BaseProduction.ChangeScale(selectedGameObject);
                    break;
            }
            
            switch (CurrentMode)
            {
                case Mode.ChangeColor:
                    BaseProduction.ChangeColor(selectedGameObject, new Color32(187, 211, 211,1 ));
                    break;
            }
        }
        
        BaseProduction.ChangePos(selectedGameObject);
        BaseProduction.ChangeScale(selectedGameObject);
        BaseProduction.ChangeMesh(selectedGameObject);
        //Debug.Log(CurrentMode);
    }
}