using UnityEngine;
using System.IO;

public class SceneLoader : MonoBehaviour
{
    public  LoadController loadController;

    private void Awake()
    {
        GlobalVariables.SaveFilePath = Application.persistentDataPath + "/SaveFile.json";

        if (!File.Exists(GlobalVariables.SaveFilePath) || string.IsNullOrEmpty(File.ReadAllText(GlobalVariables.SaveFilePath)))
        {
            File.WriteAllText(GlobalVariables.SaveFilePath, "{\"works\":[]}");
        }
        
        loadController.LoadWorks();
    }
}