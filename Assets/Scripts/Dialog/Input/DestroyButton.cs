using UnityEngine;

public class DestroyButton : MonoBehaviour
{
    public void DestroyModal()
    {
        Destroy(this.gameObject);
        GlobalVariables.slope_bool = false;
    }    
}