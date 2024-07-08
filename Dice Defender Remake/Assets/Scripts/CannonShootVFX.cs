using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShootVFX : MonoBehaviour
{

    private GameObject ShootVFX;

    private void Awake()
    {
        ShootVFX = (GameObject)Resources.Load("Prefabs/Cannon Shoot VFX");
    }

    void SpawnVFX()
    {
        Instantiate(ShootVFX, transform.position, transform.rotation);
    }

    private void OnEnable()
    {
        CannonShoot.onShoot += SpawnVFX;
    }

    private void OnDisable()
    {
        CannonShoot.onShoot -= SpawnVFX;
    }
}
