using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieSpawnAnimation : MonoBehaviour
{
    [SerializeField] private float rotationRange;
    [SerializeField] private float rotateDuration;
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private float fixRotateDuration;
    private float rotation;
    private Vector3 startPosition;
    private Collider2D col;

    private void Awake()
    {
        col = GetComponent<Collider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //UnityEngine.Random.InitState((int)DateTime.Now.Ticks);
        rotation = UnityEngine.Random.Range(-1f * rotationRange, rotationRange );
        StartCoroutine(Rotate());
        //transform.rotation = Quaternion.Euler(0, 0, rotation);
        startPosition = transform.position;
        transform.position = new Vector2(transform.position.x, transform.position.y - 4);
        StartCoroutine(LerpSmoothPosition());
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (startPosition.y - transform.position.y > 0.01f)
        //{
        //    transform.position = ExpDecay(transform.position, startPosition, 10, Time.deltaTime);
        //}
    }

    IEnumerator Rotate()
    {
        float t = 0;
        while(t < rotateDuration)
        {
            transform.GetChild(0).rotation = Quaternion.Slerp(Quaternion.identity, Quaternion.Euler(0, 0, rotation), curve.Evaluate(t / rotateDuration));
            t += Time.deltaTime;
            yield return null;
        }
        transform.GetChild(0).rotation = Quaternion.Euler(0, 0, rotation);
    }

    public void fixRotation()
    {
        StopCoroutine(Rotate());
        StartCoroutine(FixRotate());
    }

    IEnumerator FixRotate()
    {
        float t = 0;
        if (Mathf.Abs(transform.GetChild(0).rotation.z) < 0.001f) yield break;
        while (t < fixRotateDuration)
        {
            transform.GetChild(0).rotation = Quaternion.Slerp(Quaternion.Euler(0, 0, rotation), Quaternion.identity, curve.Evaluate(t / fixRotateDuration));
            t += Time.deltaTime;
            yield return null;
        }
        transform.GetChild(0).rotation = Quaternion.identity;
    }

    IEnumerator LerpSmoothPosition()
    {
        while(startPosition.y - transform.position.y > 0.01f)
        {
            transform.position = ExpDecay(transform.position, startPosition, 10, Time.deltaTime);
            yield return null;
        }
        transform.position = startPosition;
    }

    Vector2 ExpDecay(Vector2 a, Vector2 b, float decay, float dt)
    {
        return b + (a - b) * Mathf.Exp(-decay * dt);
    }
}
