using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerupDrag : MonoBehaviour, IDraggable
{
    bool gettingDragged;
    Vector2 mousePos;
    Vector2 dragOffset;

    public PowerUpManager.PowerUps powerUp;

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

    public void OnRightClick()
    {
        if (PowerUpManager.GetInstance().TryEnablePowerup(powerUp))
        {
            Destroy(gameObject);
        }
    }
}
