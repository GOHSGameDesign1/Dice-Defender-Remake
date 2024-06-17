using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subtracting : MonoBehaviour
{
    private Slot[] slots = new Slot[2];
    private Transform[] spawnPoints = new Transform[2];

    public GameObject diePrefab;

    private void Awake()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = transform.GetChild(i).GetComponent<Slot>();
        }

        spawnPoints[0] = transform.GetChild(2);
        spawnPoints[1] = transform.GetChild(3);
    }

    void MinusDice()
    {
        Debug.Log("Add Event");
        if (!SlotsAreFull()) return;

        DieNumber die1 = slots[0].currentDie;
        DieNumber die2 = slots[1].currentDie;

        int diff = Mathf.Abs(die1.getDieNumber() - die2.getDieNumber());

        Debug.Log(die1.getDieNumber() + " - " + die2.getDieNumber() + " = " + (diff));

        if (diff > 1)
        {
            GameObject spawnedDie = Instantiate(diePrefab, spawnPoints[0].transform.position, Quaternion.identity);
            spawnedDie.GetComponent<DieNumber>().setDieNumber(diff);
        }
        else
        {
            GameObject spawnedDie = Instantiate(diePrefab, spawnPoints[0].transform.position, Quaternion.identity);
            spawnedDie.GetComponent<DieNumber>().setDieNumber(1);
        }

        DestroyDice();
    }

    bool SlotsAreFull()
    {
        foreach (Slot slot in slots)
        {
            if (slot.currentDie == null) return false;
        }

        return true;
    }

    void DestroyDice()
    {
        foreach (Slot slot in slots)
        {
            slot.DestroyDie();
        }
    }

    private void OnEnable()
    {
        MouseDragging.onMouseUp += MinusDice;
    }

    private void OnDisable()
    {
        MouseDragging.onMouseUp -= MinusDice;
    }
}
