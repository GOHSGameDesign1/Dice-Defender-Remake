using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRotateAnim : MonoBehaviour
{
    private RectTransform rect;

    [SerializeField] private AnimationCurve curve;
    [SerializeField] private float rotationDuration;
    [SerializeField] Vector2 rotationBounds;
    [SerializeField] private float highlightScaleAmount;

    private bool isHighlighted;
    private Vector3 startScale;


    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        startScale = transform.localScale;
    }


    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(rotateAnim());
        isHighlighted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isHighlighted)
        {
            rect.localScale = ExpDecay(rect.localScale, startScale * highlightScaleAmount, 16, Time.unscaledDeltaTime);
        }
        else
        {
            rect.localScale = ExpDecay(rect.localScale, startScale, 16, Time.unscaledDeltaTime);
        }
    }

    private IEnumerator rotateAnim()
    {
        while (true)
        {
            float t = 0;
            rotationDuration = Mathf.Clamp(rotationDuration, 1, 999);
            while (t < rotationDuration)
            {
                rect.rotation = Quaternion.Slerp(Quaternion.Euler(0, 0, rotationBounds.x), Quaternion.Euler(0, 0, rotationBounds.y), curve.Evaluate(t / rotationDuration));
                t += Time.unscaledDeltaTime;
                yield return null;
            }
            t = 0;
            rect.rotation = Quaternion.Euler(0, 0, rotationBounds.y);
            while (t < rotationDuration)
            {
                rect.rotation = Quaternion.Slerp(Quaternion.Euler(0, 0, rotationBounds.y), Quaternion.Euler(0, 0, rotationBounds.x), curve.Evaluate(t / rotationDuration));
                t += Time.unscaledDeltaTime;
                yield return null;
            }
            rect.rotation = Quaternion.Euler(0, 0, rotationBounds.x);

        }
    }

    Vector3 ExpDecay(Vector3 a, Vector3 b, float decay, float dt)
    {
        return b + (a - b) * Mathf.Exp(-decay * dt);
    }

    public void EnableHiglight()
    {
        isHighlighted = true;
    }
    public void DisableHighlight()
    {
        isHighlighted = false;
    }
}
