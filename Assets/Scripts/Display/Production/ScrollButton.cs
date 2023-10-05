using UnityEngine;
using UnityEngine.UI;

public class ScrollButton : MonoBehaviour {
    public Scrollbar scrollbar; // Scrollbarコンポーネント

    public void RightButton()
    {
        // newPositionは0から1の範囲で指定する
        scrollbar.value = scrollbar.value + 0.5f;
    }

    public void LeftButton()
    {
        // newPositionは0から1の範囲で指定する
        scrollbar.value = scrollbar.value - 0.5f;
    }
}