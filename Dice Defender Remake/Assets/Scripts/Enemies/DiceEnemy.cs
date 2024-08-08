using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DiceEnemy : MonoBehaviour, ISpawnable
{
    private DieNumber dieNumber;
    public float timerDecrease;

    protected GameObject tooltipVFX;

    private void Awake()
    {
        dieNumber = GetComponent<DieNumber>();
        tooltipVFX = (GameObject)Resources.Load("Prefabs/Enemy Tooltip VFX");
    }

    public void OnSpawn()
    {
        dieNumber.setDieNumber(Random.Range(1, 7));
    }

    public void OnSplit(int num)
    {
        dieNumber.setDieNumber(num);
    }

    public void Die()
    {
        UpdateManagers();



        Destroy(gameObject);
    }

    protected void DeSpawn()
    {
        Destroy(gameObject);
    }

    public void SpawnTooltipVFX()
    {
        GameObject vfx = Instantiate(tooltipVFX, transform.position, Quaternion.identity);
        vfx.transform.GetChild(0).GetComponent<TextMeshPro>().text = "Needs " + dieNumber.getDieNumber() + "!";
    }

    void UpdateManagers()
    {
        PointsManager.GetInstance().UpdateCombo(false);
        PointsManager.GetInstance().AddPoints(PointsManager.PointSpawns.DieEnemy);
        PointsManager.GetInstance().SpawnPointVFX(PointsManager.PointSpawns.DieEnemy, transform.position);
        DiceManager.GetInstance().DecreaseTimer(DiceManager.TimerSpawns.DieEnemy);
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
            if(projDie.getDieNumber() == dieNumber.getDieNumber())
            {

                Die();

                if (collision.TryGetComponent(out ProjectileDeath projectileDeath))
                {
                    projectileDeath.Die();
                }

                if (transform.TryGetComponent(out SplitEnemyLogic split))
                {
                    split.Split();
                }

            } else
            {
                SpawnTooltipVFX();
            }
        }
    }
}
