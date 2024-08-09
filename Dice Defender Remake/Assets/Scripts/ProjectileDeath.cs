using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDeath : MonoBehaviour
{
    [SerializeField] private bool canExplode;

    private GameObject explodeEffect;

    private void Awake()
    {
        explodeEffect = (GameObject)Resources.Load("Prefabs/Explode Powerup FX");
    }

    public void Die()
    {
        if (canExplode)
        {
            Instantiate(explodeEffect, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }

    public void SetPowerUps()
    {
        PowerUpManager instance = PowerUpManager.GetInstance();

        canExplode = instance.explodeActive;

        instance.RemoveShootPowerUps();
    }
}
