using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFunction : MonoBehaviour
{
    public Vector2 direction;
    public float speed;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = direction.normalized * speed;
    }
}
