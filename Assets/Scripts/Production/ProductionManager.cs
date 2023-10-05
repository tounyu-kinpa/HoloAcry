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
        selectedGameObjects.Add(GameObject.Find("Cube"));
        Debug.Log(Color.HSVToRGB(99, 63, 50).r);
        ProductionFunction.ChangeColorRGB(selectedGameObjects, Color.HSVToRGB(99, 63,50));
    }

    // Update is called once per frame
    void Update()
    {
        
        if (selectedGameObjects == null)
        {
        }
        else
        {
            

        }
        //ProductionFunction.ChangePos(selectedGameObjects[0]);
        //ProductionFunction.ChangeScale(selectedGameObjects[0]);
        ProductionFunction.MoveCamera();
        ProductionFunction.RotateCamera();
    }
}