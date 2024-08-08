using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthEnemy : MonoBehaviour, ISpawnable
{

    public TextMeshPro m_TextMeshPro;

    [SerializeField] private int maxHealth;
    public float timerDecreaseHit;
    public float timerDecreaseDeath;
    public int pointsToAddOnHit;
    public int pointsToAddOnDeath;
    private int health;

    private void Awake()
    {
        //m_TextMeshPro = transform.GetChild(0).GetComponent<TextMeshPro>();
    }

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

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            HealthManager.GetInstance().DecreaseHealth(1);
            DeSpawn();
        }



        if (!collision.CompareTag("Projectile")) return;

        if(collision.TryGetComponent(out DieNumber die))
        {
            TakeDamage(die.getDieNumber());
        }

        if (collision.TryGetComponent(out ProjectileDeath projectileDeath))
        {
            projectileDeath.Die();
        }
    }

    void Die()
    {
        PointsManager.GetInstance().UpdateCombo(false);
        PointsManager.GetInstance().AddPoints(PointsManager.PointSpawns.HealthEnemyKill);
        PointsManager.GetInstance().SpawnPointVFX(PointsManager.PointSpawns.HealthEnemyKill, transform.position);
        DiceManager.GetInstance().DecreaseTimer(DiceManager.TimerSpawns.HealthEnemyKill);
        Destroy(gameObject);
    }

    void DeSpawn()
    {
        Destroy(gameObject);
    }


    public void TakeDamage(int dmg)
    {
        health -= dmg;
        health = Mathf.Clamp(health, 0, maxHealth);
        m_TextMeshPro.text = health.ToString();

        if (health <= 0)
        {
            Die();
        }
        else
        {
            //PointsManager.GetInstance().AddPoints(PointsManager.PointSpawns.HealthEnemyHit);
            //PointsManager.GetInstance().SpawnPointVFX(PointsManager.PointSpawns.HealthEnemyHit, transform.position);
            //DiceManager.GetInstance().DecreaseTimer(DiceManager.TimerSpawns.HealthEnemyHit);
        }
    }
}
