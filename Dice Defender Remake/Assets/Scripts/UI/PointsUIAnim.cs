using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsUIAnim : MonoBehaviour
{

    private TextMeshProUGUI tmp;

    private void Awake()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        StartCoroutine(PointTallyAnim());
        Debug.Log("POINTS!!");
    }

    IEnumerator PointTallyAnim()
    {
        float t = 0;

        while(t < 5)
        {
            int currentPoints = (int)Mathf.Lerp(0, PointsManager.GetInstance().points, t / 5f);
            tmp.text = currentPoints.ToString();
            t += Time.deltaTime;
            yield return null;
        }

        tmp.text = PointsManager.GetInstance().points.ToString();
    }
}
