using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDragging : MonoBehaviour
{

    private IDraggable currentlyDraggingObject;

    public delegate void OnMouseUp();
    public static event OnMouseUp onMouseUp;

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
            if(hit.transform.TryGetComponent(out currentlyDraggingObject))
            {
                currentlyDraggingObject.OnClick();
            }
        }
    }

    void StopDragging()
    {
        if (currentlyDraggingObject == null)
        {
            return;
        }
        currentlyDraggingObject.OnEndClick();
        currentlyDraggingObject = null;

        if (onMouseUp != null)
        {
            onMouseUp.Invoke();
        }

    }
}
