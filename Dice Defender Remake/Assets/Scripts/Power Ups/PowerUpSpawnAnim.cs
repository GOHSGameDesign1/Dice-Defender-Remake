using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawnAnim : MonoBehaviour
{

    Vector2 spawnPos = Vector2.zero;
    private void Awake()
    {
        spawnPos = transform.position;
    }

    private void OnEnable()
    {
        transform.position = new Vector2(transform.position.x, -10);
        StartCoroutine(LerpSmoothPosition());
    }

    IEnumerator LerpSmoothPosition()
    {
        while (Vector2.Distance(transform.position, spawnPos) > 0.01f)
        {
            transform.position = ExpDecay(transform.position, spawnPos, 10, Time.deltaTime);
            yield return null;
        }
        transform.position = spawnPos;
    }

    Vector2 ExpDecay(Vector2 a, Vector2 b, float decay, float dt)
    {
        return b + (a - b) * Mathf.Exp(-decay * dt);
    }
}
