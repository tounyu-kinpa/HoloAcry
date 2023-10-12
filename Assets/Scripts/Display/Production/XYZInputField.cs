using UnityEngine;
using TMPro;
using Display.Production;

public class XYZInputField : MonoBehaviour
{
    private TMP_InputField inputField;
    public ErrorAlert alert;

    private void Start() 
    {
        inputField = this.gameObject.GetComponent<TMP_InputField>();
    }

    public void SetScale()
    {
        if (ProductionManager.selectedGameObjects[0] != null)
        {
            Vector3 scale = ProductionManager.selectedGameObjects[0].transform.localScale;

            if (float.TryParse(inputField.text, out float floatValue))
            {
                switch (this.gameObject.transform.name)
                {
                    case "X_InputField":
                        ProductionFunction.ChangeScaleByUI(floatValue, scale.y, scale.z);
                        break;

                    case "Y_InputField":
                        ProductionFunction.ChangeScaleByUI(scale.x, floatValue, scale.z);
                        break;
                    
                    case "Z_InputField":
                        ProductionFunction.ChangeScaleByUI(scale.x, scale.y, floatValue);
                        break;
                    
                    default:
                        break;
                }
            }
            else
            {
                alert.ShowInputTypeErrorModal(GlobalVariables.ParentsUI);
            }
        }
        else
        {
            alert.ShowNoSelectErrorModal(GlobalVariables.ParentsUI);
        }
    }

    public void SetRotation()
    {
        if (ProductionManager.selectedGameObjects[0] != null)
        {
            Vector3 rotation = ProductionManager.selectedGameObjects[0].transform.localEulerAngles;

            if (float.TryParse(inputField.text, out float floatValue))
            {
                switch (this.gameObject.transform.name)
                {
                    case "X_InputField":
                        ProductionFunction.ChangeRotation(floatValue, rotation.y, rotation.z);
                        break;

                    case "Y_InputField":
                        ProductionFunction.ChangeRotation(rotation.x, floatValue, rotation.z);
                        break;
                    
                    case "Z_InputField":
                        ProductionFunction.ChangeRotation(rotation.x, rotation.y, floatValue);
                        break;
                    
                    default:
                        break;
                }
            }
            else
            {
                alert.ShowInputTypeErrorModal(GlobalVariables.ParentsUI);
            }
        }
        else
        {
            alert.ShowNoSelectErrorModal(GlobalVariables.ParentsUI);
        }
    }

    public void SetSlope()
    {
        if (ProductionManager.selectedGameObjects[0] != null)
        {
            if (float.TryParse(inputField.text, out float floatValue))
            {
                ProductionFunction.ChangeSlope(floatValue);
            }
            else
            {
                alert.ShowInputTypeErrorModal(GlobalVariables.ParentsUI);
            }
        }
        else
        {
            alert.ShowNoSelectErrorModal(GlobalVariables.ParentsUI);
        }
    }
}