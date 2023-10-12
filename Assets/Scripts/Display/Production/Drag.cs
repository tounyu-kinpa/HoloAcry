using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    private Vector3 initialPosition;
    private Vector3 dragStartPos;
    private bool isDragging = false;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
                isDragging = true;
                dragStartPos = Input.mousePosition;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector3 dragDelta = Input.mousePosition - dragStartPos;
            Vector3 moveVector = new Vector3(dragDelta.x, dragDelta.y, 0) * 0.01f;
            transform.position = initialPosition + moveVector;
            dragStartPos = Input.mousePosition;
        }
    }
}