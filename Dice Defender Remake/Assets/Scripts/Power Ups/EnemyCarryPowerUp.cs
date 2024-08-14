using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class EnemyCarryPowerUp : MonoBehaviour
{
    public PowerUpManager.PowerUps powerup;

    void SpawnPowerUp()
    {
        PowerUpManager.GetInstance().SpawnPowerUp(powerup);
    }

    private void Awake()
    {
        powerup = (PowerUpManager.PowerUps)Random.Range(0, Enum.GetNames(typeof(PowerUpManager.PowerUps)).Length);
    }

    private void OnEnable()
    {
        if (TryGetComponent(out EnemyBase enemy))
        {
            enemy.onDeath += SpawnPowerUp;
        }
    }

    private void OnDisable()
    {
        if (TryGetComponent(out EnemyBase enemy))
        {
            enemy.onDeath -= SpawnPowerUp;
        }
    }
}
