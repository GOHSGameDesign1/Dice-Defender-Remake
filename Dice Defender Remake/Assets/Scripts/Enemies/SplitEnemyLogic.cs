using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitEnemyLogic : MonoBehaviour
{
    private DieNumber dieNumber;
    private GameObject dieEnemyPrefab;

    private void Awake()
    {
        dieNumber = GetComponent<DieNumber>();
        dieEnemyPrefab = (GameObject)Resources.Load("Prefabs/Die Enemy");
    }

    public void Split()
    {
        int num1 = 0;
        int num2 = 0;

        num1 = dieNumber.getDieNumber() / 2;
        num2 = dieNumber.getDieNumber() / 2;
        if (dieNumber.getDieNumber() % 2 == 1)
        {
            num2 = num1 + 1;
        }

        GameObject spawnedEnemy = Instantiate(dieEnemyPrefab, transform.position + Vector3.up * 0.5f, Quaternion.identity);
        if (spawnedEnemy.TryGetComponent(out DiceEnemy enemy))
        {
            enemy.OnSplit(num1);
        }

        spawnedEnemy = Instantiate(dieEnemyPrefab, transform.position - Vector3.up * 0.5f, Quaternion.identity);
        if (spawnedEnemy.TryGetComponent(out DiceEnemy enemy2))
        {
            enemy2.OnSplit(num2);
        }
    }
}
