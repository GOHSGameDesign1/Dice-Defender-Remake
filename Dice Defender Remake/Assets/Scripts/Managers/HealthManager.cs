using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int maxHealth;

    public static HealthManager instance;

    private void Awake()
    {
        if (instance != null) return;
        instance = this;

    }

    public static HealthManager GetInstance() { return instance; }

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DecreaseHealth(int dmg)
    {
        health -= dmg;
        health = Mathf.Clamp(health, 0, maxHealth);

        if(health <= 0)
        {
            GameManager.GetInstance().GameOver();
        }
    }
}
