using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    private Rigidbody2D rb;

    public float stepTime;
    public float moveAmount;

    private GameObject walkVFX;
    public float VFXSpawnOffset;

    private EnemyAnimation enemyAnimation;

    private Vector2 targetPosition;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        walkVFX = (GameObject)Resources.Load("Prefabs/Enemy Move VFX");
        enemyAnimation = GetComponent<EnemyAnimation>();
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
        WaitForSeconds waitTime = new WaitForSeconds(stepTime);
        while (true)
        {
            yield return waitTime;
            if(enemyAnimation != null)
            {
                enemyAnimation.AnimateMove();
            }
            targetPosition -= new Vector2(moveAmount, 0);
        }
    }

    Vector2 ExpDecay(Vector2 a, Vector2 b, float decay, float dt)
    {
        return b + (a - b) * Mathf.Exp(-decay * dt);
    }
}
