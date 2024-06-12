using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonRotate : MonoBehaviour
{

    private Vector2 mousePos;
    private Vector2 direction;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        direction = mousePos - (Vector2)transform.position;

        transform.rotation = Quaternion.Euler(0, 0, -1f * Mathf.Rad2Deg * (Mathf.Atan2(direction.x, direction.y)) + 90f);
    }
}
