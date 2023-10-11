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
        if (float.TryParse(inputField.text, out float floatValue))
        {
            switch (this.gameObject.transform.name)
            {
                case "X_InputField":
                    // ProductionFunction.ChangeRotation(floatValue, rotation.y, rotation.z);
                    break;

                case "Y_InputField":
                    // ProductionFunction.ChangeRotation(rotation.x, floatValue, rotation.z);
                    break;
                
                case "Z_InputField":
                    // ProductionFunction.ChangeRotation(rotation.x, rotation.y, floatValue);
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

    public void SetRotation()
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
}