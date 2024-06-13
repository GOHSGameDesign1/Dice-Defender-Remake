using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceDrag : MonoBehaviour, IDraggable
{
    bool gettingDragged;
    Vector2 mousePos;
    Vector2 dragOffset;

    // Start is called before the first frame update
    void Start()
    {
        gettingDragged = false;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (gettingDragged) transform.position = mousePos + dragOffset;
    }

    public void OnClick()
    {
        gettingDragged=true;
        dragOffset = (Vector2)transform.position - mousePos;
    }

    public void OnEndClick()
    {
        gettingDragged = false;
    }
}
