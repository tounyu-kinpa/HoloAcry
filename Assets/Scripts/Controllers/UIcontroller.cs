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

    void Start()
    {
        
    }

    void Update()
    {
        
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
        ProductionUI.SetActive(true);
    }

    // 設定画面を表示
    public void ShowSettingUI()
    {
        ProductionUI.SetActive(false);
        SettingUI.SetActive(true);
    }

    // 再生画面を表示
    public void ShowPlayUI()
    {
        SettingUI.SetActive(false);
        ListUI.SetActive(false);
        PlayUI.SetActive(true);
    }

}
