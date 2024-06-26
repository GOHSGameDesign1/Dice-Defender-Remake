using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adding : MonoBehaviour
{
    private Slot[] slots = new Slot[2];
    private Transform[] spawnPoints = new Transform[2];

    public GameObject diePrefab;

    public float timerDecrease;
    public int pointsToAdd;

    private void Awake()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            slots[i] = transform.GetChild(i).GetComponent<Slot>();
        }

        spawnPoints[0] = transform.GetChild(2);
        spawnPoints[1] = transform.GetChild(3);
    }

    void AddDice()
    {
        if (!SlotsAreFull()) return;

        DieNumber die1 = slots[0].currentDie;
        DieNumber die2 = slots[1].currentDie;

        int sum = die1.getDieNumber() + die2.getDieNumber();

        Debug.Log(die1.getDieNumber() + " + " + die2.getDieNumber() + " = " + (sum));

        if(sum <= 6)
        {
            GameObject spawnedDie = Instantiate(diePrefab, spawnPoints[0].transform.position, Quaternion.identity);
            spawnedDie.GetComponent<DieNumber>().setDieNumber(sum);
        } else
        {
            GameObject spawnedDie = Instantiate(diePrefab, spawnPoints[0].transform.position, Quaternion.identity);
            spawnedDie.GetComponent<DieNumber>().setDieNumber(6);

            spawnedDie = Instantiate(diePrefab, spawnPoints[1].transform.position, Quaternion.identity);
            spawnedDie.GetComponent <DieNumber>().setDieNumber(sum-6);
        }

        if(die1.getDieNumber() < 6 && die2.getDieNumber() < 6)
        {
            PointsManager.GetInstance().AddPoints(pointsToAdd);
            DiceManager.GetInstance().DecreaseTimer(timerDecrease);
        }


        DestroyDice();
    }

    bool SlotsAreFull()
    {
        foreach(Slot slot in slots)
        {
            if (slot.currentDie == null) return false;
        }

        return true;
    }

    void DestroyDice()
    {
        foreach(Slot slot in slots)
        {
            slot.DestroyDie();
        }
    }

    private void OnEnable()
    {
        MouseDragging.onMouseUp += AddDice;
    }

    private void OnDisable()
    {
        MouseDragging.onMouseUp -= AddDice;
    }
}
