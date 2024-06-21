using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceTracker : MonoBehaviour
{
    private void Start()
    {
        GameManager.GetInstance().numberOfDice++;
    }

    private void OnDestroy()
    {
        GameManager.GetInstance().numberOfDice--;
    }
}
