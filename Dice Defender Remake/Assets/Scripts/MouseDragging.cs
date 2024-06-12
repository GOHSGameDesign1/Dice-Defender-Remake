using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDragging : MonoBehaviour
{

    private Transform currentlyDraggingObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SendRaycast();
        }

        if(Input.GetMouseButtonUp(0))
        {
            StopDragging();
        }
    }

    void SendRaycast()
    {
        Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

        if (hit)
        {
            if(hit.transform.TryGetComponent(out IDraggable draggableObject))
            {
                currentlyDraggingObject = hit.transform;
                draggableObject.OnClick();
            }
        }
    }

    void StopDragging()
    {
        if (!currentlyDraggingObject)
        {
            return;
        }

        if(currentlyDraggingObject.TryGetComponent(out IDraggable draggableObject)){ 
            draggableObject.OnEndClick();
        }
        currentlyDraggingObject = null;

    }
}
