using UnityEngine;

public class ShowInputUIPrefab : MonoBehaviour
{
    public GameObject ImportPrefab;

    public void CreateUI()
    {
        Instantiate(ImportPrefab, GlobalVariables.ParentsUI);
    }   
}