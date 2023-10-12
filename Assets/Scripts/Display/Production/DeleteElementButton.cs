using UnityEngine;
using Display.Production;

public class DeleteElementButton : MonoBehaviour
{
    public ErrorAlert alert;

    public void DestroyElement()
    {
        if (ProductionManager.selectedGameObjects.Count == 0)
        {
            alert.ShowNoSelectErrorModal(GlobalVariables.ParentsUI);
        }
        else
        {
            ProductionManager.createdGameObjects.Remove(ProductionManager.selectedGameObjects[0]);
            
            Destroy(GlobalVariables.content.transform.Find(ProductionManager.selectedGameObjects[0].transform.name).gameObject);
            Destroy(ProductionManager.selectedGameObjects[0]);
        }
    }
}