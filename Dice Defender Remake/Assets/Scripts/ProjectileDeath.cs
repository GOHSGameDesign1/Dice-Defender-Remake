using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDeath : MonoBehaviour
{
    [SerializeField] private bool canExplode;

    public void Die()
    {
        if (canExplode)
        {
            Debug.Log("EXPLODE!!!");
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
