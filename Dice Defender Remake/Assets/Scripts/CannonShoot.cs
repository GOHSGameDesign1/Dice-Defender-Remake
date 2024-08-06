using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShoot : MonoBehaviour
{
    private Slot slot;
    private Transform cannonSprite;

    public GameObject dieProj;

    public delegate void OnShoot();
    public static event OnShoot onShoot;

    private void Awake()
    {
        cannonSprite = transform.GetChild(0);
        slot = transform.GetChild(1).GetComponent<Slot>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (slot.currentDie == null) return;

            Debug.Log("Shooting Die: " +  slot.currentDie.getDieNumber());
            ShootDie();
        }
    }

    void ShootDie()
    {
        onShoot.Invoke(); // Just for VFX Spawn
        GameObject proj = Instantiate(dieProj, cannonSprite.GetChild(0).position, Quaternion.identity);
        proj.GetComponent<ProjectileFunction>().direction = cannonSprite.right;
        proj.GetComponent<DieNumber>().setDieNumber(slot.currentDie.getDieNumber());
        proj.GetComponent<ProjectileDeath>().SetPowerUps();

        slot.DestroyDie();
    }
}
