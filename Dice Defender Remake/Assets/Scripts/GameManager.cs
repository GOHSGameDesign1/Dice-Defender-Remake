using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField]public int numberOfDice;

    public GameObject diePrefab;
    public Transform diceSpawnPoints;

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.Log("Multiple GameManagers found in the scene!");
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public static GameManager GetInstance()
    {
        return Instance;
    }

    private void Update()
    {
        if(numberOfDice <= 0)
        {
            for(int i = 0; i < 3; i++)
            {
                Instantiate(diePrefab, diceSpawnPoints.GetChild(i).position, Quaternion.identity);
            }
        }
    }
}
