using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.EventSystems;

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
        ProductionFunction.ChangeColorRGB(ProductionManager.selectedGameObjects, new Color32(0, 0, 0, 0));
        Debug.Log("クリック");
    }
    
}
