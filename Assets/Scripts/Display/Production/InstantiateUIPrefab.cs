using UnityEngine;
using Display.Production;
using TMPro;

public class InstantiateUIPrefab : MonoBehaviour
{
    public GameObject RotateUI;
    public GameObject ScaleUI;
    public GameObject SlopeUI;

    public GameObject Sliders;
    public Transform Under;

    private GameObject rotate;
    private GameObject scale;
    private GameObject slope;

    private bool rotate_bool = false;
    private bool scale_bool = false;
    private bool slope_bool = false;

    private void Start() {
        showScaleUI();
    }

    private void Update() {
        if (ProductionManager.selectedGameObjects.Count == 0)
        {
            DestroyRotateUI();
            showScaleUI();
        }
    }

    public void showRotateUI()
    {
        if (!rotate_bool)
        {
            rotate = Instantiate(RotateUI, Under);
            // GameObject slider = Instantiate(Sliders, GlobalVariables.ParentsUI);
            rotate_bool = true;
        }
    }

    public void showScaleUI()
    {
        if (!scale_bool)
        {
            scale = Instantiate(ScaleUI, Under);
            // GameObject sliders = Instantiate(Sliders, GlobalVariables.ParentsUI);
            scale_bool = true;
        }
        
    }

    public void showSlopeUI()
    {
        if (!slope_bool)
        {
            slope = Instantiate(SlopeUI, GlobalVariables.ParentsUI);
            slope_bool = true;
        }
    }

    public void DestroyRotateUI()
    {
        Destroy(rotate);
        rotate_bool = false;
    }

    public void DestroyScaleUI()
    {
        Destroy(scale);
        scale_bool = false;
    }

    public void DestroySlopeUI()
    {
        Destroy(slope);
        slope_bool = false;
    }

}