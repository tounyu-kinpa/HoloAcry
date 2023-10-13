using UnityEngine;
using UndoRedo.Production;
using Display.Production;


public class SetElementName : MonoBehaviour
{
    public GameObject InputElementName;

    public void SetName()
    {
        UndoRedo.Production.UndoRedo.ChangeName(true);
        Instantiate(InputElementName, GlobalVariables.ParentsUI);
    }
}