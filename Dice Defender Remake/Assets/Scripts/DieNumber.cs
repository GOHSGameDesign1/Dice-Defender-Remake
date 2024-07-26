using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieNumber : MonoBehaviour
{
    [SerializeField][Range(1,6)] private int dieNumber;

    [SerializeField] private Sprite[] dieSprites = new Sprite[6];
    public SpriteRenderer childRenderer;
    [Range(1,6)][SerializeField] int minDieNumber;

    private void Awake()
    {
        //childRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        if (childRenderer != null)
        {
            childRenderer.sprite = dieSprites[dieNumber - 1];
        }
    }

    public int getDieNumber()
    {
        return dieNumber;
    }

    public void setDieNumber(int num)
    {
        if((0 < num) && (num < 7))
        {
            dieNumber = num;
            dieNumber = Mathf.Clamp(dieNumber, minDieNumber, 6);
            if (childRenderer == null) return;
            childRenderer.sprite = dieSprites[dieNumber - 1];
        }
    }
}
