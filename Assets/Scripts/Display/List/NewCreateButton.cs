using UnityEngine;

public class WorksObject : MonoBehaviour
{
    public GameObject WorkSpace;  // 作品内のすべてのオブジェクトを格納するPrefab
    private float x = 0;
    private float y = 125;

    public void CreateWork()
    {
        // すでにある作品たちの取得
        GameObject[] works = GameObject.FindGameObjectsWithTag("WorkSpace");

        // 一個一個ずらす
        foreach (GameObject work in works)
        {
            if (work.transform.localPosition.x  == 0)
            {
                work.transform.localPosition = new Vector3(5, work.transform.position.y, 0);
            }
            else
            {
                work.transform.localPosition = new Vector3(0, work.transform.position.y - 5, 0);
            }
        }

        // WorkSpacePrefabを生成
        GameObject NewWork = Instantiate(WorkSpace);
        
        // 作品の生成位置を定義
        NewWork.transform.localPosition = new Vector3(0.0f , 0.0f, 0.0f);

        // 作品のとりあえずの命名
        NewWork.transform.name = "Work" + GlobalVariables.workNumber.ToString();

        // 編集中の作品をあらわす変数に代入
        GlobalVariables.CurrentWork = NewWork;

        GlobalVariables.workNumber++;
    }
}