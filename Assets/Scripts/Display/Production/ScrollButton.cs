using UnityEngine;
using UnityEngine.UI;

public class ScrollButton : MonoBehaviour {
    public Scrollbar scrollbar; // Scrollbarコンポーネント

    public void RightButton()
    {
        scrollbar.value = scrollbar.value + 0.5f;
    }

    public void LeftButton()
    {
        scrollbar.value = scrollbar.value - 0.5f;
    }
}