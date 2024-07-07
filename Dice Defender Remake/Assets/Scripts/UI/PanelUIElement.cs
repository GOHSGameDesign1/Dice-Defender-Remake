using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class PanelUIElement : MonoBehaviour
{
    protected RectTransform rect; 

    protected Vector2 startPos {  get; private set; }

    [SerializeField] private AnimationCurve curve;
    [SerializeField] private float rotationDuration;
    [SerializeField] Vector2 rotationBounds;

    private bool isHighlighted;

    public void Awake()
    {
        InitialSetup();
    }

    // Start is called before the first frame update
     public void OnEnable()
    {

        SpawnSetup();
    }

    protected void InitialSetup()
    {
        Debug.Log("Setup!!!");
        rect = GetComponent<RectTransform>();
        startPos = rect.position;
    }

    protected void SpawnSetup()
    {
        StartCoroutine(rotateAnim());
        isHighlighted = false;
        StartCoroutine(spawnAnim(startPos));
        //rect.position = new Vector2(0, -10f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isHighlighted)
        {
            rect.localScale = ExpDecay(rect.localScale, Vector3.one * 1.4f, 16, Time.unscaledDeltaTime);
        }
        else
        {
            rect.localScale = ExpDecay(rect.localScale, Vector3.one, 16, Time.unscaledDeltaTime);
        }
    }

    protected IEnumerator spawnAnim(Vector2 target)
    {
        rect.position = new Vector2(target.x, -10f);
        while(Vector2.Distance(rect.position, target) > 0.01f)
        {
            rect.position = ExpDecay(rect.position, target, 10, Time.unscaledDeltaTime);
            yield return null;
        }

        rect.position = target;
    }

    protected IEnumerator rotateAnim()
    {
        while (true)
        {
            float t = 0;
            rotationDuration = Mathf.Clamp(rotationDuration, 1, 999);
            while(t < rotationDuration)
            {
                rect.rotation = Quaternion.Slerp(Quaternion.Euler(0,0,rotationBounds.x), Quaternion.Euler(0,0,rotationBounds.y), curve.Evaluate(t/rotationDuration));
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
        isHighlighted=false;
    }
}
