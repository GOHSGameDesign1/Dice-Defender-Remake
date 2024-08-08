using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodePowerUp : MonoBehaviour
{
    private void OnEnable()
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, 1.2f);
        KillColliders(cols);
    }

    void KillColliders(Collider2D[] cols)
    {
        foreach (Collider2D col in cols)
        {
            if(col.TryGetComponent(out DiceEnemy dieEnemy))
            {
                dieEnemy.Die();
            }

            if(col.TryGetComponent(out HealthEnemy healthEnemy))
            {
                healthEnemy.TakeDamage(5);
            }
        }
    }
}
