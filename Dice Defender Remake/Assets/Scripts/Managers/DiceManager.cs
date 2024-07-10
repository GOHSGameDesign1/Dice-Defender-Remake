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

    [SerializeField] private int maxDice;
    public float spawnWaitTime;
    public float spawnMinimumDecreaseTime;
    [SerializeField] private float spawnTimer;

    public Vector2 spawnPoint;

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
            spawnTimer -= timeToDecrease;
            spawnTimer = Mathf.Clamp(spawnTimer, spawnMinimumDecreaseTime, 999);
        }
    }

    IEnumerator StartSpawningDice()
    {
        while(true)
        {
            if (numberOfDice == 0)
            {
                spawnTimer = spawnWaitTime;
                StartCoroutine(SpawnDice());
            }
            while (spawnTimer > 0)
            {
                yield return null;
                spawnTimer -= Time.deltaTime;
            }
            if(spawnTimer <= 0)
            {
                yield return null;
            }
        }
    }

    IEnumerator SpawnDice()
    {
        if (diceSpawnPoints == null) yield break;
        if (numberOfDice >= maxDice) yield break;
        int numToSpawn = maxDice - numberOfDice;
        numToSpawn = Mathf.Clamp(numToSpawn, 0, 3);
        for (int i = 0; i < numToSpawn; i++)
        {
            Random.InitState((int)DateTime.Now.Ticks + i);
            SpawnDie(Random.Range(1, 7));
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void SpawnDie(int num)
    {
        Vector2 spawnPos = diceSpawnPoints.GetChild(0).position;

        int counter = 0;
        while(true)
        {
            spawnPos = diceSpawnPoints.GetChild(counter%diceSpawnPoints.childCount).position;

            if (counter > 2)
            {
                spawnPos += Vector2.up * 1.5f * (counter / diceSpawnPoints.childCount);
                if (!Physics2D.OverlapArea(new Vector2(spawnPos.x - 0.5f, spawnPos.y - 0.5f), new Vector2(spawnPos.x + 0.5f, spawnPos.y + 0.5f)))
                {
                    break;
                }
            }
            else
            {
                // Checks under the screen for spawning dice if spawning the dice in an original location defined by the spawnPoints and not above any of them
                if (!Physics2D.OverlapArea(new Vector2(spawnPos.x - 0.5f, spawnPos.y - 2f), new Vector2(spawnPos.x + 0.5f, spawnPos.y + 0.5f)))
                {
                    break;
                }
            }
            counter++;
        }

        //if (!Physics2D.OverlapArea(new Vector2(spawnPos.x - 0.5f, spawnPos.y - 0.5f), new Vector2(spawnPos.x + 0.5f, spawnPos.y + 0.5f)))
        //{
        GameObject die = Instantiate(diePrefab, spawnPos, Quaternion.identity);
        die.GetComponent<DieNumber>().setDieNumber(num);
        //}
    }
}
