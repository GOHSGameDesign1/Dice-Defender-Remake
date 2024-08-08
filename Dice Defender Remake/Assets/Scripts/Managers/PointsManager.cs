using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Random = UnityEngine.Random;

public class PointsManager : MonoBehaviour
{
    public static PointsManager instance;

    public int points {  get; private set; }
    public float money { get; private set; }

    [SerializeField] private GameObject pointPrefab;

    [SerializeField] private int maxCombo;
    public int currentCombo { get; private set; }
    [SerializeField] private float comboMaxTimerLength;
    [SerializeField] private float comboCurrentTimerLength;

    public enum PointSpawns
    {
        Add,
        Minus,
        DieEnemy,
        HealthEnemyHit,
        HealthEnemyKill
    }

    [Serializable]
    public struct VALUES
    {
        public int add;
        public int minus;
        public int dieEnemy;
        public int HealthEnemyHit;
        public int HealthEnemyKill;
    }

    [SerializeField] private VALUES values;

    //TODO Make ComboUpdate an Event for UI top respond

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(instance );
            return;
        }

        instance = this;
    }

    public static PointsManager GetInstance()
    {
           return instance;
    }

    public void AddPoints(PointSpawns pointSpawns)
    {
        int pointsToAdd = findPointValue(pointSpawns);
        int add = (currentCombo > 0) ? (pointsToAdd * currentCombo) : pointsToAdd;
        Debug.Log(add);
        points += add;
        AddMoney(add / 100f);
    }

    public void AddMoney(float addAmount)
    {
        money += addAmount;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentCombo = 0;
        points = 0;
    }

    public void SpawnPointVFX(PointSpawns pointSpawns, Vector2 position)
    {
        int textPoints = findPointValue(pointSpawns);
        GameObject text = Instantiate(pointPrefab, position, Quaternion.Euler(0, 0, Random.Range(-45f, 45f)));

        if(currentCombo > 0)
        {
            textPoints *= currentCombo;
        }

        if(text.transform.GetChild(0).TryGetComponent(out TextMeshPro tmp))
        {
            tmp.text = "+" + textPoints.ToString();
        }
    }

    public void UpdateCombo(bool incCombo)
    {

        currentCombo = incCombo ? currentCombo + 1 : currentCombo;
        currentCombo = Mathf.Clamp(currentCombo, 0, maxCombo);

        if (currentCombo <= 0) return;
        if(comboCurrentTimerLength > 0)
        {
            comboCurrentTimerLength = comboMaxTimerLength;
        } else if(comboCurrentTimerLength <= 0)
        {
            comboCurrentTimerLength = comboMaxTimerLength;
            StartCoroutine(ComboTimer());
        }
    }

    int findPointValue(PointSpawns pointSpawns)
    {
        switch ((int)pointSpawns)
        {
            case 0:
                return values.add;
            case 1:
                return values.minus;
            case 2:
                return values.dieEnemy;
            case 3:
                return values.HealthEnemyHit;
            case 4:
                return values.HealthEnemyKill;
            default:
                return -1;
        }
    }

    IEnumerator ComboTimer()
    {
        while(comboCurrentTimerLength > 0)
        {
            comboCurrentTimerLength -= Time.deltaTime;
            yield return null;
        }
        comboCurrentTimerLength = 0;
        currentCombo = 0;
    }

    public float GetMaxComboTime()
    {
        return comboMaxTimerLength;
    }

    public float GetCurrentComboTime()
    {
        return comboCurrentTimerLength;
    }


}
