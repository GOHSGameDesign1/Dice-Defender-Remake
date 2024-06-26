using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawning : MonoBehaviour
{
    [SerializeField] private Vector2 xRange, yRange, spawnTimeRange;
    [SerializeField] private GameObject[] spawnables;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartSpawning());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartSpawning()
    {
        WaitForSeconds waitTime;
        while (true)
        {
            float time = Random.Range(spawnTimeRange.x, spawnTimeRange.y);
            waitTime = new WaitForSeconds(time);
            Spawn();
            yield return waitTime;
        }
    }

    void Spawn()
    {
        Debug.Log("Spawning Enemy");
        GameObject enemyToSpawn = spawnables[Random.Range(0, spawnables.Length)];

        Vector2 spawnPoint = new Vector2(Random.Range(xRange.x, xRange.y),
            Random.Range(yRange.x, yRange.y));

        GameObject spawnedEnemy = Instantiate(enemyToSpawn, spawnPoint, Quaternion.identity);
        if(spawnedEnemy.TryGetComponent(out ISpawnable enemy))
        {
            enemy.OnSpawn();
        }
    }
}
