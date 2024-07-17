using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShopItemPanelManager : MonoBehaviour
{
    private List<RectTransform> items = new List<RectTransform>();
    private List<Vector2> itemPositions = new List<Vector2>();
    public int index;
    public float scrolltime;
    private void Awake()
    {
        index = 0;

        for(int i = 0; i < transform.childCount; i++)
        {
            items.Add(transform.GetChild(i).GetComponent<RectTransform>());
            itemPositions.Add(Vector2.right * i * 1280f);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //ScrollRight();
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < items.Count; i++)
        {
            items[i].anchoredPosition = ExpDecay(items[i].anchoredPosition, itemPositions[i], 10, Time.deltaTime);
        }
    }

    public void ScrollRight()
    {
        Debug.Log("YES!!");
        if (index >= items.Count - 1) return;
        index++;

        UpdatePositions();
    }

    public void ScrollLeft()
    {
        if (index <= 0) return;
        index--;
        UpdatePositions();

    }

    void UpdatePositions()
    {
        for (int i = 0; i < itemPositions.Count; i++)
        {
            Vector2 pos = itemPositions[i];

            pos = Vector2.right * (i - index) * 1280f;
            //pos += Vector2.up * -167.93f;

            itemPositions[i] = pos;
        }
    }

    Vector3 ExpDecay(Vector3 a, Vector3 b, float decay, float dt)
    {
        return b + (a - b) * Mathf.Exp(-decay * dt);
    }
}
