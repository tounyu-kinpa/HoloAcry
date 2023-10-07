using UnityEngine;

public class SetWorkName : MonoBehaviour
{
    public GameObject InputNamePrefab;
    public Transform SettingsCanvas;

    public ErrorAlert errorAlert;

    // 作品名を設定する関数
    public void SetName()
    {
        // 名前入力用のPrefabをインスタンス化
        GameObject InputModal = Instantiate(InputNamePrefab, SettingsCanvas);

        // 自作コンポーネントの取得
        InputNamePrefab ModalClass = InputModal.GetComponent<InputNamePrefab>();

        // ユーザーが入力した作品名を取得
        string NewWorkName = ModalClass.GetInputFieldText();

        if (string.IsNullOrEmpty(NewWorkName))
        {
            // 入力されてなかったらアラートダイアログを表示
            errorAlert.ShowUnSetInputFieldErrorModal(SettingsCanvas);
        }
        else
        {
            // 入力されてたら名前入力のPrefabを消す
            ModalClass.DestroyModal();
            // 作品名を変更する
            GlobalVariables.CurrentWork.transform.name = NewWorkName;
        }
    }
}