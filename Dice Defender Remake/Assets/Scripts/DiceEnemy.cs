using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceEnemy : MonoBehaviour, ISpawnable
{
    private DieNumber dieNumber;
    public float timerDecrease;
    public int pointsToAdd;

    private void Awake()
    {
        dieNumber = GetComponent<DieNumber>();
    }

    public void OnSpawn()
    {
        dieNumber.setDieNumber(Random.Range(1, 7));
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

                PointsManager.GetInstance().AddPoints(pointsToAdd);
                DiceManager.GetInstance().DecreaseTimer(timerDecrease);
                Destroy(gameObject);
            }
        }
    }
}
