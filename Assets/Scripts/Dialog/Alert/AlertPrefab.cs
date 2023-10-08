using UnityEngine;

public class AlertPrefab : MonoBehaviour
{
    public void OKButton()
    {
        //ErrorModalの了解ボタンが押されたらModalを削除
        Destroy(this.gameObject);
    }    
}