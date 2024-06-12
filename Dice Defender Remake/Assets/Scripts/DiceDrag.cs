using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceDrag : MonoBehaviour, IDraggable
{
    bool gettingDragged;

    // Start is called before the first frame update
    void Start()
    {
        gettingDragged = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(gettingDragged) transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void OnClick()
    {
        gettingDragged=true;
    }

    public void OnEndClick()
    {
        gettingDragged = false;
    }
}
