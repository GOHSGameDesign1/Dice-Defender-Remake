using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    private bool goingToDie;

    public delegate void OnDeath();
    public event OnDeath onDeath;

    private void Awake()
    {
        goingToDie = false;
    }

    protected void DeSpawn()
    {
        Destroy(gameObject);
    }

    public void Die()
    {
        if (goingToDie) return;
        goingToDie = true;
        UpdateManagers();
        if(onDeath != null) onDeath();
        Destroy(gameObject);
    }

    public virtual void UpdateManagers()
    {

    }

    public virtual void OnHit(DieNumber projDie, ProjectileDeath projDeath)
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            HealthManager.GetInstance().DecreaseHealth(1);
            DeSpawn();
        }

        if (!collision.CompareTag("Projectile")) return;
        if (collision.TryGetComponent(out DieNumber projDie))
        {
            if(collision.TryGetComponent(out ProjectileDeath projDeath))
            OnHit(projDie, projDeath);
        }
    }
}
