using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShake : MonoBehaviour
{
    public float shakeStrength;
    public float shakeDelay;

    [SerializeField] private bool shaking;
    private Vector2 startPos;

    // Start is called before the first frame update
    void Start()
    {
        shaking = true;
    }

    private void OnEnable()
    {
        startPos = transform.localPosition;
        StartCoroutine(Shake());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Shake()
    {
        WaitForSeconds waitTime = new WaitForSeconds(shakeDelay);
        while (shaking)
        {
            transform.localPosition = startPos + (Vector2.right * Random.Range(-1f, 1f) * shakeStrength) + (Vector2.up * Random.Range(-1f, 1f) * shakeStrength);
            yield return waitTime;
        }
    }
}
