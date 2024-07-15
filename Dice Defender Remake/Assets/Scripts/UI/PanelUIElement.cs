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
        rect = GetComponent<RectTransform>();
        startPos = rect.position;
    }

    protected void SpawnSetup()
    {
        StartCoroutine(spawnAnim(startPos));
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

    Vector3 ExpDecay(Vector3 a, Vector3 b, float decay, float dt)
    {
        return b + (a - b) * Mathf.Exp(-decay * dt);
    }    
}
