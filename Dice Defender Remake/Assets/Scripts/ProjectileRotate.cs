using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileRotate : MonoBehaviour
{
    private Rigidbody2D rb;

    public float rotateAmount;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.rotation += rotateAmount;
    }
}
