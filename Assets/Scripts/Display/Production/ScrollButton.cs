using UnityEngine;
using UnityEngine.UI;

public class ScrollButton : MonoBehaviour {
    public Scrollbar scrollbar; // Scrollbarコンポーネント

    public void RightButton()
    {
        scrollbar.value = (0 <= scrollbar.value && scrollbar.value < 0.5f) ? 0.5f : 1.0f;
    }

    public void LeftButton()
    {
        scrollbar.value = (1 >= scrollbar.value && scrollbar.value > 0.5f) ? 0.5f : 0.0f;
    }
}