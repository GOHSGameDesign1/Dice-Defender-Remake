using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public static PowerUpManager instance;

    public bool explodeActive;

    public enum PowerUps
    {
        Explode
    }

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
