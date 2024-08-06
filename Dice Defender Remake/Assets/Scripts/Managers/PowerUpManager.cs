using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public static PowerUpManager instance;

    public bool explodeActive;

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
