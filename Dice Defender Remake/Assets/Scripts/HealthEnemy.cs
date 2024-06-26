using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthEnemy : MonoBehaviour, ISpawnable
{

    private TextMeshPro m_TextMeshPro;

    [SerializeField] private int maxHealth;
    public float timerDecreaseHit;
    public float timerDecreaseDeath;
    public int pointsToAddOnHit;
    public int pointsToAddOnDeath;
    private int health;

    private void Awake()
    {
        m_TextMeshPro = transform.GetChild(0).GetComponent<TextMeshPro>();
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
        if (!collision.CompareTag("Projectile")) return;

        if(collision.TryGetComponent(out DieNumber die))
        {
            TakeDamage(die.getDieNumber());

            if(health <= 0)
            {
                Die();
            } else
            {
                PointsManager.GetInstance().AddPoints(pointsToAddOnHit);
                DiceManager.GetInstance().DecreaseTimer(timerDecreaseHit);
            }
        }

        if (collision.TryGetComponent(out ProjectileDeath projectileDeath))
        {
            projectileDeath.Die();
        }
    }

    void Die()
    {
        PointsManager.GetInstance().UpdateCombo(false);
        PointsManager.GetInstance().AddPoints(pointsToAddOnDeath);
        DiceManager.GetInstance().DecreaseTimer(timerDecreaseDeath);
        Destroy(gameObject);
    }


    public void TakeDamage(int dmg)
    {
        health -= dmg;
        health = Mathf.Clamp(health, 0, maxHealth);
        m_TextMeshPro.text = health.ToString();
    }
}
