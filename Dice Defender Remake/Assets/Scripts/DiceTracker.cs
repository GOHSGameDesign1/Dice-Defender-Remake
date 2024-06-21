using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceTracker : MonoBehaviour
{
    private void Start()
    {
        DiceManager.GetInstance().IncreaseDiceNumber();
    }

    private void OnDestroy()
    {
        DiceManager.GetInstance().DecreaseDiceNumber();
    }
}
