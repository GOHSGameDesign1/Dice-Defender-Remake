using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ComboMeter : MonoBehaviour
{
    private float fillAmount;

    private Image image;


    private void Awake()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        fillAmount = PointsManager.GetInstance().GetCurrentComboTime() / PointsManager.GetInstance().GetMaxComboTime();
        image.fillAmount = ExpDecay(image.fillAmount, fillAmount, 16, Time.deltaTime);
    }

    float ExpDecay(float a, float b, float decay, float dt)
    {
        return b + (a - b) * Mathf.Exp(-decay * dt);
    }
}
