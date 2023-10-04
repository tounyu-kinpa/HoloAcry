using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePrefab : MonoBehaviour
{
    // プレハブ格納用
    public GameObject HolePrefab;
    public GameObject WallPrefab;
    public GameObject canvas;

    public int n = 4;//適当に入れて生成されるかテストする。後でxmlなどにある数値を参照する。

    // Start is called before the first frame update
    void Start()
    {
        n += 1;//nの見掛け上の値と実際に生成されるprefabの差が1、戻り値を設定する場合は-1する。

        GameObject Obj;


        if (n == 0)
        {
            Vector3 vec = new Vector3(0.0f, 0.0f, 0.0f);
            Vector3 vec2 = new Vector3(830.0f, 0.0f, 0.0f);

            for (int i = 1; i < 30; i++) //30という数値は適当後で変える
            {
                if ((i % 2) == 1)
                {
                    Obj = Instantiate(WallPrefab, vec, Quaternion.identity);
                    Obj.transform.SetParent(canvas.transform, false);
                    vec.y -= 880.0f;
                }

                if ((i % 2) == 0)
                {
                    Obj = Instantiate(WallPrefab, vec2, Quaternion.identity);
                    Obj.transform.SetParent(canvas.transform, false);
                    vec2.y -= 880.0f;
                }
                
            }
        }

        if (0 < n)
        {
            Vector3 vec = new Vector3(0.0f, 0.0f, 0.0f);
            Vector3 vec2 = new Vector3(830.0f, 0.0f, 0.0f);

            for (int i = 1; i < n; i++) //30という数値は適当後で変える
            {
                if ((i % 2) == 1)
                {
                    Obj = Instantiate(HolePrefab, vec, Quaternion.identity);
                    Obj.transform.SetParent(canvas.transform, false);
                    vec.y -= 880.0f;
                }

                if ((i % 2) == 0)
                {
                    Obj = Instantiate(HolePrefab, vec2, Quaternion.identity);
                    Obj.transform.SetParent(canvas.transform, false);
                    vec2.y -= 880.0f;
                }
                if ((n - 1) == i)//最後のループであれば
                {
                    for (; i < 30; i++) //30という数値は適当後で変える
                    {
                        vec2.x = 900.0f;
                        if ((i % 2) == 1)
                        {
                            Obj = Instantiate(WallPrefab, vec, Quaternion.identity);
                            Obj.transform.SetParent(canvas.transform, false);
                            vec.y -= 880.0f;
                        }

                        if ((i % 2) == 0)
                        {
                            Obj = Instantiate(WallPrefab, vec2, Quaternion.identity);
                            Obj.transform.SetParent(canvas.transform, false);
                            vec2.y -= 880.0f;
                        }

                    }
                }
                
            }
            
        }


    }
}

    // Update is called once per frame
