using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public static PowerUpManager instance;

    public bool explodeActive;

    public Transform spawnPoint;

    public enum PowerUps
    {
        Explode
    }

    public GameObject[] powerUpOrbs; // Should be in the same order as the powerups enum

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public static PowerUpManager GetInstance()
    {
        return instance;
    }

    public void RemoveShootPowerUps()
    {
        explodeActive = false;
    }

    // Returns true if enabling is successful, false if failed
    public bool TryEnablePowerup(PowerUps powerUp)
    {
        switch (powerUp)
        {
            case PowerUps.Explode:
                if (!explodeActive)
                {
                    explodeActive=true;
                    return true;
                } else
                {
                    return false;
                }
            default:
                Debug.LogWarning("Power Up Not Found!");
                return false;
        }
    }

    public void SpawnPowerUp(PowerUps powerUp)
    {
        if((int)powerUp >= powerUpOrbs.Length || (int)powerUp < 0)
        {
            return;
        }
        Debug.Log("works");
        Instantiate(powerUpOrbs[(int)powerUp], (Vector3)Random.insideUnitCircle * 2 + spawnPoint.position, Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            SpawnPowerUp(PowerUps.Explode);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
