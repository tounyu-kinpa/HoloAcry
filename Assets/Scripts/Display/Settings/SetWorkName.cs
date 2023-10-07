using UnityEngine;

public class SetWorkName : MonoBehaviour
{
    public GameObject InputNamePrefab;
    public Transform SettingsCanvas;

    public ErrorAlert errorAlert;

    private GameObject InputModal;

    // 作品名を設定する関数
    public void SetName()
    {
        GlobalVariables.ParentsUI = SettingsCanvas;
        // 名前入力用のPrefabをインスタンス化
        InputModal = Instantiate(InputNamePrefab, SettingsCanvas);
    }
}