using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthUIDisplay : MonoBehaviour
{
    private TextMeshProUGUI tmp;

    private void Awake()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        tmp.text = "Health: " + HealthManager.GetInstance().health + "/" + HealthManager.GetInstance().GetMaxHealth();
    }
}
