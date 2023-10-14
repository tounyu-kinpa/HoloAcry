using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    public static GameObject CurrentWork;
    public static string SaveFilePath;
    public static Transform ParentsUI;
    public static GameObject content;
    public static int workNumber = 1;
    public static GameObject ElementContent;

    public bool isUIEventHandled = false;

    public static bool slope_bool = false;
    
    public bool GetSetProperty  //public 戻り値 プロパティ名
    { 
        get { return isUIEventHandled; } //get {return フィールド名;}
    }

}