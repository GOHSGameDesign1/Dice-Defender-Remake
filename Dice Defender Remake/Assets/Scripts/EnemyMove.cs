using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    private Rigidbody2D rb;
    private SpriteRenderer render;

    public float stepTime;
    public float moveAmount;

    public Sprite[] walkSprites;

    private Vector2 targetPosition;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        render = transform.GetChild(1).GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartMoving());
        targetPosition = rb.position;
    }

    // Update is called once per frame
    void Update()
    {
        rb.position = ExpDecay(rb.position, targetPosition, 10, Time.deltaTime);
    }

    IEnumerator StartMoving()
    {
        int counter = 0;
        WaitForSeconds waitTime = new WaitForSeconds(stepTime);
        while (true)
        {
            if (walkSprites.Length > 0)
            {
                render.sprite = walkSprites[counter];
                counter++;
                counter = counter % walkSprites.Length;
            }
            yield return waitTime;
            targetPosition -= new Vector2(moveAmount, 0);
        }
    }

    Vector2 ExpDecay(Vector2 a, Vector2 b, float decay, float dt)
    {
        return b + (a - b) * Mathf.Exp(-decay * dt);
    }
}
