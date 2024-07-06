using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelUIElement : MonoBehaviour
{
    private RectTransform rect; 
    private Animator animator;

    private Vector2 startPos;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        transform.TryGetComponent<Animator>(out animator);
    }

    // Start is called before the first frame update
    void Start()
    {
        startPos = rect.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartSpawnAnim()
    {
        StartCoroutine(spawnAnim(startPos));
    }

    IEnumerator spawnAnim(Vector2 target)
    {
        Debug.Log("Spawning");
        rect.position = new Vector2(target.x, -10f);
        while(Vector2.Distance(rect.position, target) > 0.01f)
        {
            rect.position = ExpDecay(rect.position, target, 10, Time.unscaledDeltaTime);
            yield return null;
        }

        rect.position = target;
    }

    Vector2 ExpDecay(Vector2 a, Vector2 b, float decay, float dt)
    {
        return b + (a - b) * Mathf.Exp(-decay * dt);
    }
}
