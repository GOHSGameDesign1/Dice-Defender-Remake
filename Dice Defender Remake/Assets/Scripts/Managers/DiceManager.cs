using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class DiceManager : MonoBehaviour
{
    public static DiceManager instance;

    public int numberOfDice {  get; private set; }

    public GameObject diePrefab;
    public Transform diceSpawnPoints;

    public float spawnWaitTime;
    public float spawnMinimumDecreaseTime;
    [SerializeField] private float spawnTimer;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

        StartCoroutine(StartSpawningDice());
    }

    public static DiceManager GetInstance()
    {
        return instance;
    }

    public void IncreaseDiceNumber()
    {
        numberOfDice++;
        CheckDiceNumber();
    }

    public void DecreaseDiceNumber()
    {
        numberOfDice--;
        CheckDiceNumber();
    }

    void CheckDiceNumber()
    {
        numberOfDice = Mathf.Clamp(numberOfDice, 0 , 999);

        if (diceSpawnPoints == null) return;

        if(numberOfDice <= 0)
        {
            //SpawnDice();
        }
    }

    public float GetSpawnTimer()
    {
        return spawnTimer;
    }

    public void DecreaseTimer(float timeToDecrease)
    {
        if(spawnTimer > spawnMinimumDecreaseTime)
        {
            spawnTimer *= timeToDecrease;
            spawnTimer = Mathf.Clamp(spawnTimer, spawnMinimumDecreaseTime, 999);
        }
    }

    IEnumerator StartSpawningDice()
    {
        while(true)
        {
            spawnTimer = spawnWaitTime;
            StartCoroutine(SpawnDice());
            while (spawnTimer > 0)
            {
                spawnTimer -= Time.deltaTime;
                yield return null;
            }
        }
    }

    IEnumerator SpawnDice()
    {
        if (diceSpawnPoints == null) yield break;
        if (numberOfDice >= 6) yield break;
        for (int i = 0; i < 3; i++)
        {
            Random.InitState((int)DateTime.Now.Ticks + i);
            GameObject die = Instantiate(diePrefab, diceSpawnPoints.GetChild(i).position, Quaternion.identity);
            die.GetComponent<DieNumber>().setDieNumber(Random.Range(1, 7));
            yield return null;
        }
    }
}
