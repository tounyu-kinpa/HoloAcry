using UnityEngine;

public class SetColorButton : MonoBehaviour
{
    public GameObject ColorUIPrefab;
    public Transform ProductionUI;

    private GameObject ColorSetUI;

    public void CreateColorSetUI()
    {
        ColorSetUI = Instantiate(ColorUIPrefab, ProductionUI);
    }
}