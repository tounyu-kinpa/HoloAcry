using UnityEngine;
using Display.Production;

public class SetColorButton : MonoBehaviour
{
    public GameObject ColorUIPrefab;
    public Transform ProductionUI;
    public ErrorAlert alert;

    private GameObject ColorSetUI;

    public void CreateColorSetUI()
    {
        if (ColorSetUI != null)
        {
            return;
        }

        if (ProductionManager.selectedGameObjects.Count == 0)
        {
            alert.ShowNoSelectErrorModal(GlobalVariables.ParentsUI);
        }
        else
        {
            ColorSetUI = Instantiate(ColorUIPrefab, ProductionUI);
            GlobalVariables.isUIEventHandled = true;
        }
    }
}