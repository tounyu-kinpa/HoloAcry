using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;

public class ProductionManager : MonoBehaviour
{
    public static Mode CurrentMode = Mode.ChangeColor;

    public static List<GameObject> selectedGameObjects = new List<GameObject>();

    public static GameObject CurrentWork;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (selectedGameObjects == null)
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
        }
        //BaseProduction.ChangePos(selectedGameObject);
        //BaseProduction.ChangeScale(selectedGameObject);
        //Debug.Log(CurrentMode);
    }
}