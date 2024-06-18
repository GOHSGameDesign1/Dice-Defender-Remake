using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    private Rigidbody2D rb;

    public float stepTime;
    public float moveAmount;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartMoving());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator StartMoving()
    {
        WaitForSeconds waitTime = new WaitForSeconds(stepTime);
        while (true)
        {
            yield return waitTime;
            rb.position -= new Vector2(moveAmount, 0);
        }
    }
}
