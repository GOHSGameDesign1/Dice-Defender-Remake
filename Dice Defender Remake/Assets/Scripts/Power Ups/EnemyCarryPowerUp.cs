using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCarryPowerUp : MonoBehaviour
{
    public PowerUpManager.PowerUps powerup;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnPowerUp()
    {
        PowerUpManager.GetInstance().SpawnPowerUp(powerup);
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
