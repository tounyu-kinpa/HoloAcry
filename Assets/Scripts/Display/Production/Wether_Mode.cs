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
    void Start()
    {
        setScript = GetComponent<set>();
        Mode=0;
        switch (Mode)
        {
            case (int)Whether_type.rain:
                //ここにアニメーションの呼び出しを書く
                ame_Script.Start();
                break;
            case (int)Whether_type.cloud:
                kumo_Script.Start();
                break;
            case (int)Whether_type.thunder:
                kaminari_Script.Start();
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