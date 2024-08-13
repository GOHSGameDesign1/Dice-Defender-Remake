using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DiceEnemy : EnemyBase, ISpawnable
{
    private DieNumber dieNumber;

    protected GameObject tooltipVFX;

    //private bool goingToDie;

    private void Awake()
    {
        dieNumber = GetComponent<DieNumber>();
        tooltipVFX = (GameObject)Resources.Load("Prefabs/Enemy Tooltip VFX");
        //goingToDie = false;
    }

    public void OnSpawn()
    {
        dieNumber.setDieNumber(Random.Range(1, 7));
    }

    public void OnSplit(int num)
    {
        dieNumber.setDieNumber(num);
    }

    public void SpawnTooltipVFX()
    {
        GameObject vfx = Instantiate(tooltipVFX, transform.position, Quaternion.identity);
        vfx.transform.GetChild(0).GetComponent<TextMeshPro>().text = "Needs " + dieNumber.getDieNumber() + "!";
    }

    public override void UpdateManagers()
    {
        PointsManager.GetInstance().UpdateCombo(false);
        PointsManager.GetInstance().AddPoints(PointsManager.PointSpawns.DieEnemy);
        PointsManager.GetInstance().SpawnPointVFX(PointsManager.PointSpawns.DieEnemy, transform.position);
        DiceManager.GetInstance().DecreaseTimer(DiceManager.TimerSpawns.DieEnemy);
    }

    public override void OnHit(DieNumber projDie, ProjectileDeath projDeath)
    {
        Debug.Log("Hit");
        if (projDie.getDieNumber() == dieNumber.getDieNumber())
        {
            projDeath.Die();

            Die();
        }
        else
        {
            SpawnTooltipVFX();
        }
    }
}
