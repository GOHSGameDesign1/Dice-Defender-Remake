using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ComboNumber : MonoBehaviour
{
    private TextMeshProUGUI tmp;

    private void Awake()
    {
        tmp = GetComponent<TextMeshProUGUI>(); 
    }

    // Update is called once per frame
    void Update()
    {
        tmp.text = "x" + PointsManager.GetInstance().currentCombo.ToString();
    }
}
