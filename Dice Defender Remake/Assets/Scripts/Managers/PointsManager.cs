using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsManager : MonoBehaviour
{
    public static PointsManager instance;

    public int points {  get; private set; }

    [SerializeField] private GameObject pointPrefab;

    [SerializeField] private int maxCombo;
    public int currentCombo { get; private set; }
    [SerializeField] private float comboMaxTimerLength;
    [SerializeField] private float comboCurrentTimerLength;

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

    public void AddPoints(int pointsToAdd)
    {
        int add = (currentCombo > 0) ? (pointsToAdd * currentCombo) : pointsToAdd;
        Debug.Log(add);
        points += add;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentCombo = 0;
        points = 0;
    }

    public void SpawnPointVFX(int points, Vector2 position)
    {
        GameObject text = Instantiate(pointPrefab, position, Quaternion.identity);

        if(currentCombo > 0)
        {
            points *= currentCombo;
        }

        if(text.transform.GetChild(0).TryGetComponent(out TextMeshPro tmp))
        {
            tmp.text = points.ToString();
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
