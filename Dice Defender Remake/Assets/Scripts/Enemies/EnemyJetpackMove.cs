using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJetpackMove : MonoBehaviour
{
    public float moveSpeed;
    public float amplitude;
    public float period;
    public float shift;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = Vector2.left * moveSpeed;
        StartCoroutine(MoveY());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MoveY()
    {
        float t = 0;
        float startY = rb.position.y;
        float frequency = (Mathf.PI * 2) / period;
        while(true)
        {
            rb.position = new Vector2(rb.position.x, amplitude * Mathf.Sin(frequency * (t + shift) ));
            t += Time.deltaTime;
            yield return null;
        }
    }
}
