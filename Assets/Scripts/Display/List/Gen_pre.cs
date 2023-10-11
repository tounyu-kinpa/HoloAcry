using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePrefab : MonoBehaviour
{
    // プレハブ格納用
    public GameObject Panel;
    public GameObject Wall;
    public GameObject ListUI;

    public int n = GlobalVariables.workNumber + 1;//適当に入れて生成されるかテストする。後でxmlなどにある数値を参照する。

    GameObject Obj;

    // Start is called before the first frame update
    public void OnClick()
    {

        if (n == 0)
        {
            Vector3 vec = new Vector3(0.0f, 0.0f, 0.0f);
            Vector3 vec2 = new Vector3(900.0f, 0.0f, 0.0f);

            for (int i = 1; i < 30; i++) //30という数値は適当後で変える
            {
                if ((i % 2) == 1)
                {
                    Obj = Instantiate(Wall, vec, Quaternion.identity);
                    Obj.transform.SetParent(ListUI.transform, false);
                    vec.y -= 880.0f;
                }

                if ((i % 2) == 0)
                {
                    Obj = Instantiate(Wall, vec2, Quaternion.identity);
                    Obj.transform.SetParent(ListUI.transform, false);
                    vec2.y -= 880.0f;
                }

            }
        }

        n += 1;//nの見掛け上の値と実際に生成されるprefabの差が1、戻り値を設定する場合は-1する。

        if (0 < n)
        {
            Vector3 vec = new Vector3(0.0f, 0.0f, 0.0f);
            Vector3 vec2 = new Vector3(830.0f, 0.0f, 0.0f);

            for (int i = 1; i < n; i++) //30という数値は適当後で変える
            {
                if ((i % 2) == 1)
                {
                    Obj = Instantiate(Panel, vec, Quaternion.identity);
                    Obj.transform.SetParent(ListUI.transform, false);
                    vec.y -= 880.0f;
                }

                if ((i % 2) == 0)
                {
                    Obj = Instantiate(Panel, vec2, Quaternion.identity);
                    Obj.transform.SetParent(ListUI.transform, false);
                    vec2.y -= 880.0f;
                }
                if ((n - 1) == i)//最後のループであれば
                {
                    for (; i < 30; i++) //30という数値は適当後で変える
                    {
                        vec2.x = 900.0f;
                        if ((i % 2) == 1)
                        {
                            Obj = Instantiate(Wall, vec, Quaternion.identity); ;
                            Obj.transform.SetParent(ListUI.transform, false);
                            vec.y -= 880.0f;
                        }

                        if ((i % 2) == 0)
                        {
                            Obj = Instantiate(Wall, vec2, Quaternion.identity);
                            Obj.transform.SetParent(ListUI.transform, false);
                            vec2.y -= 880.0f;
                        }

                    }
                }

            }

        }

        /*for (int i = 0; i < n; i++)
        {
            Obj = Instantiate(Panel);
            Obj.transform.SetParent(ListUI.transform, false);
        }
        for (int i = 0; i < 20; i++)
        {
            Obj = Instantiate(Wall);
            Obj.transform.SetParent(ListUI.transform, false);
        }*/


    }

}

// Update is called once per frame
