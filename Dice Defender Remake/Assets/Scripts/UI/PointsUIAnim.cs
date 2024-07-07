using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsUIAnim : MonoBehaviour
{

    private TextMeshProUGUI tmp;

    public ParticleSystem particles;

    public float animLength;

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

        while(t < animLength)
        {
            int currentPoints = (int)Mathf.Lerp(0, PointsManager.GetInstance().points, t / animLength);
            tmp.text = currentPoints.ToString();
            t += Time.deltaTime;
            yield return null;
        }

        tmp.text = PointsManager.GetInstance().points.ToString();
        Instantiate(particles, transform.position, Quaternion.Euler(-90, 0, 0));
    }
}
