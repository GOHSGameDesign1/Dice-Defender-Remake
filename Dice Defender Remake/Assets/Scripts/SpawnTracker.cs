using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnTracker : MonoBehaviour
{
    private float fillAmount;

    private Image image;


    private void Awake()
    {
        image = GetComponent<Image>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fillAmount = DiceManager.GetInstance().GetSpawnTimer() / DiceManager.GetInstance().spawnWaitTime;
        image.fillAmount = ExpDecay(image.fillAmount, fillAmount, 16, Time.deltaTime);
    }

    float ExpDecay(float a, float b, float decay, float dt)
    {
        return b+(a-b)*Mathf.Exp(-decay * dt);
    }
}
