using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Enumを適切な場所で定義する
public enum Whether_type
{
    rain,
    cloud,
    thunder,
    sunny,
    snow
}
public class Whether_Mode : MonoBehaviour
{
   
public int whether;
public set setScript;
public yuki yuki_Script;
public kaminari kaminari_Script;
public ame ame_Script;
public kumo kumo_Script;
public hikouki hikouki_Script;

    // Startメソッドを使い、Mainメソッドの代わりに実行する
    void Start()
    {
        setScript = GetComponent<set>();
        //
        whether = (int)Whether_type.thunder;
        switch (whether)
        {
            case (int)Whether_type.rain:
                //ここにアニメーションの呼び出しを書く
                ame_Script.Start();
                break;
            case (int)Whether_type.cloud:
                kumo_Script.Start();
                break;
            case (int)Whether_type.thunder:
                setScript.Start();
                break;
            case (int)Whether_type.sunny:
                hikouki_Script.Start();
                break;
            case (int)Whether_type.snow:
                yuki_Script.Start();
                break;
        }
    }

}