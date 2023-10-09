using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// UIの遷移を行うクラス
public class UIController : MonoBehaviour
{
    public GameObject ListUI;
    public GameObject ProductionUI;
    public GameObject SettingUI;
    public GameObject PlayUI;

    public CreatePrefab list;

    private void Start()
    {
        GlobalVariables.ParentsUI = this.ListUI.transform;
    }
    

    // 一覧画面を表示
    public void ShowListUI()
    {
        PlayUI.SetActive(false);
        ListUI.SetActive(true);
    }

    // 制作画面を表示
    public void ShowProductionUI()
    {
        ListUI.SetActive(false);
        SettingUI.SetActive(false);
        ProductionUI.SetActive(true);

        GlobalVariables.ParentsUI = this.ProductionUI.transform;
    }

    // 設定画面を表示
    public void ShowSettingUI()
    {
        GlobalVariables.ParentsUI = this.SettingUI.transform;
        ProductionUI.SetActive(false);
        SettingUI.SetActive(true);
    }

    // 再生画面を表示
    public void ShowPlayUI()
    {
        GlobalVariables.ParentsUI = this.PlayUI.transform;
        SettingUI.SetActive(false);
        ListUI.SetActive(false);
        PlayUI.SetActive(true);
    }

}
