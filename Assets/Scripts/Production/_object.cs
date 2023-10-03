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
        ProductionFunction.ChangeSlope(ProductionManager.selectedGameObjects[0]);
        Debug.Log("クリック");
    }
    
}
