using UnityEngine;

public class WorksObject : MonoBehaviour
{
    public GameObject WorkSpace;  // 作品内のすべてのオブジェクトを格納するPrefab
    private float x = 0;
    private float y = 125;
    public void CreateWork()
    {
        // Prefabを生成
        GameObject NewWork = Instantiate(WorkSpace);

        // 作品が偶数個めなら右、奇数個めなら左
        x = ( this.transform.childCount % 2 ) == 0 ? 125.0f : 0.0f;
        // 作品が奇数個めならyの位置を下げる、偶数個めなら1個前の作品と一緒の位置
        y = ( this.transform.childCount % 2 ) == 0 ? y : y - 125.0f;
        
        // 作品の生成位置を定義
        NewWork.transform.localPosition = new Vector3(x , y, 0.0f);

        // 作品のとりあえずの命名
        NewWork.transform.name = "Work" + this.transform.childCount.ToString();

        // 編集中の作品をあらわす変数に代入
        GlobalVariables.CurrentWork = NewWork;
    }
}