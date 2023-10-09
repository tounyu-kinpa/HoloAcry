using UnityEngine;

public class SetElementName : MonoBehaviour
{
    public GameObject InputElementName;

    public void SetName()
    {
        Instantiate(InputElementName, GlobalVariables.ParentsUI);
    }
}