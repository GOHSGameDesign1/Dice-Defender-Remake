using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthEnemy : EnemyBase, ISpawnable
{

    public TextMeshPro m_TextMeshPro;

    [SerializeField] private int maxHealth;
    private int health;

    public void OnSpawn()
    {
        maxHealth = Random.Range(4, 10);
    }

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        m_TextMeshPro.text = health.ToString();
    }

    public override void OnHit(DieNumber projDie, ProjectileDeath projDeath)
    {
        TakeDamage(projDie.getDieNumber());
        projDeath.Die();
    }

    public override void UpdateManagers()
    {
        PointsManager.GetInstance().UpdateCombo(false);
        PointsManager.GetInstance().AddPoints(PointsManager.PointSpawns.HealthEnemyKill);
        PointsManager.GetInstance().SpawnPointVFX(PointsManager.PointSpawns.HealthEnemyKill, transform.position);
        DiceManager.GetInstance().DecreaseTimer(DiceManager.TimerSpawns.HealthEnemyKill);
    }


    public void TakeDamage(int dmg)
    {
        health -= dmg;
        health = Mathf.Clamp(health, 0, maxHealth);
        m_TextMeshPro.text = health.ToString();

        if (health <= 0)
        {
            Debug.Log("Called Death");
            Die();
        }
    }
}
