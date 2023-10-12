using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScaleByDrag : MonoBehaviour
{
    public Camera camera;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1)
        {
            Ray ray = camera.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            Vector3 pos = gameObject.transform.position;

            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
                pos.x = camera.ScreenToWorldPoint(Input.touches[0].position).x;
            }


        }
    }
}
