using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceEnemy : MonoBehaviour
{
    private DieNumber dieNumber;

    private void Awake()
    {
        dieNumber = GetComponent<DieNumber>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Projectile")) return;
        if (collision.TryGetComponent(out DieNumber projDie))
        {
            if(projDie.getDieNumber() == dieNumber.getDieNumber())
            {

                if(collision.TryGetComponent(out ProjectileDeath projectileDeath))
                {
                    projectileDeath.Die();
                }

                Destroy(gameObject);
            }
        }
    }
}
