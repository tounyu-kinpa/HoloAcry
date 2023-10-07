using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveController : MonoBehaviour
{
    // 作品をセーブする関数
    public void SaveElements()
    {
        // データを格納するクラスをインスタンス化
        Work WorkData = new Work();

        // 作品内のすべてのElementのデータをWorkDataに格納
        StoreElementData(GlobalVariables.CurrentWork, WorkData);
        Debug.Log("格納したよ");

        Debug.Log(WorkData);
        
        // ファイルへの書き込み
        InsertNewSaveData(WorkData);
    }

    // 格納したい作品、格納先を引数として作品内のすべてのオブジェクトを格納する関数
    private void StoreElementData(GameObject CurrentWork, Work WorkData)
    {
        // 作品名を格納
        WorkData.work_name = CurrentWork.transform.name;

        // WorkDataクラス内のelementsを初期化
        WorkData.elements = new List<Element>();
        
        // 作品内のすべてのオブジェクトのデータを格納
        foreach (Transform child in CurrentWork.transform)
        {
            GameObject element = child.gameObject;
            Debug.Log("Elementの名前 " + element.transform.name);

            // Elementの色の情報を取得
            Color elementColor = element.GetComponent<Renderer>().material.color;
            MeshFilter elementMeshFilter = element.GetComponent<MeshFilter>();

            // Elementのデータを格納
            Element elementData = new Element
            {
                name         = element.transform.name,
                elementType  = element.tag,
                scale        = element.transform.localScale,
                position     = element.transform.localPosition,
                rotate       = element.transform.localEulerAngles,
                meshVertices = elementMeshFilter.mesh.vertices,
                color_R      = elementColor.r,
                color_G      = elementColor.g,
                color_B      = elementColor.b,
                color_A      = elementColor.a
            };
            
            // Elementのデータが入ったelementDataをWorkDataに格納
            WorkData.elements.Add(elementData);
        }
    }

    // ファイルに書き込みをする関数
    private void InsertNewSaveData(Work WorkData)
    {
        // すでに保存されているデータを取得
        string OriginalFileData = File.ReadAllText(GlobalVariables.SaveFilePath);

        // セーブファイルになにも書かれていなかったら下のように書き込む
        if (OriginalFileData == "")
        {
            File.WriteAllText(GlobalVariables.SaveFilePath, "{\"works\":[]}");
        }
        // WorkDataをJson文字列に変換
        string InsertData = JsonUtility.ToJson(WorkData);
        InsertData = OriginalFileData.Length > 12 ? "," + InsertData : InsertData;

        // WorkDataのインサート位置を定義
        int position = OriginalFileData.Length - 2;

        // WorkDataをインサートした文字列の生成
        string NewFileData = OriginalFileData.Substring(0, position) + InsertData + OriginalFileData.Substring(position);

        // ファイルへの書き込み
        File.WriteAllText(GlobalVariables.SaveFilePath, NewFileData);
    }
}