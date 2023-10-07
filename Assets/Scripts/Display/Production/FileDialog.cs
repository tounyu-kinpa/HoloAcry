using UnityEngine;

public class FileDialogExample : MonoBehaviour
{
    private AndroidJavaObject currentActivity;

    private void Start()
    {
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
    }

    public void OpenNativeFileDialog()
    {
        AndroidJavaClass fileDialogPlugin = new AndroidJavaClass("FileDialog.FileDialogPlugin");
        fileDialogPlugin.CallStatic("OpenFileDialog", currentActivity);
    }
}