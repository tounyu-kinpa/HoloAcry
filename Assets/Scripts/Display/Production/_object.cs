using UnityEngine;
using UnityEngine.EventSystems;
using Display.Production;

public class _object : MonoBehaviour, IPointerClickHandler
{

    public MeshRenderer mesh;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        ProductionManager.selectedGameObjects.Add(gameObject);
        ProductionFunction.ChangeColorRGB(new Color32(0, 0, 0, 0));
        Debug.Log("クリック");
    }
    
}
