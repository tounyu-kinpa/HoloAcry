using UnityEngine;
using TMPro;
using Display.Production;

public class LocalPositionPanel : MonoBehaviour
{
    private TextMeshProUGUI elementName;
    private TextMeshProUGUI value_x;
    private TextMeshProUGUI value_y;
    private TextMeshProUGUI value_z;

    private void Start() {
        elementName = this.gameObject.transform.Find("ElementName").gameObject.GetComponent<TextMeshProUGUI>();

        value_x = this.gameObject.transform.Find("value_x").gameObject.GetComponent<TextMeshProUGUI>(); 
        value_y = this.gameObject.transform.Find("value_y").gameObject.GetComponent<TextMeshProUGUI>(); 
        value_z = this.gameObject.transform.Find("value_z").gameObject.GetComponent<TextMeshProUGUI>(); 
    }
    
    private void Update() {
        SetPositionValue();
    }

    public void SetPositionValue()
    {
        if (ProductionManager.selectedGameObjects.Count != 0 && ProductionManager.selectedGameObjects[0] != null)
        {
            elementName.text = ProductionManager.selectedGameObjects[0].transform.name;   

            value_x.text = ProductionManager.selectedGameObjects[0].transform.localPosition.x.ToString();
            value_y.text = ProductionManager.selectedGameObjects[0].transform.localPosition.y.ToString();
            value_z.text = ProductionManager.selectedGameObjects[0].transform.localPosition.z.ToString();
        }
        else
        {
            elementName.text = "立体名";   

            value_x.text = "X";
            value_y.text = "Y";
            value_z.text = "Z";
        } 
    }
    
}