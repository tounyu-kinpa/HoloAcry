using UnityEngine;

public class SetWorkName : MonoBehaviour
{
    public GameObject InputNamePrefab;
    public Transform SettingsCanvas;
    public UIController controller;

    public ErrorAlert errorAlert;

    private GameObject InputModal;

    private bool InputName = false;

    // 作品名を設定する関数
    public void SetName()
    {
        if (InputName)
        {
            controller.ShowPlayUI();
        }
        else
        {
            // 名前入力用のPrefabをインスタンス化
            InputModal = Instantiate(InputNamePrefab, SettingsCanvas);
            InputName = true;
        }
    }
}