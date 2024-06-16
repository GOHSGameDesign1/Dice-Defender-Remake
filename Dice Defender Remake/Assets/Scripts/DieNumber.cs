using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieNumber : MonoBehaviour
{
    [SerializeField][Range(1,6)] private int dieNumber;

    [SerializeField] private Sprite[] dieSprites = new Sprite[6];
    private SpriteRenderer childRenderer;

    private void Awake()
    {
        childRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        childRenderer.sprite = dieSprites[dieNumber - 1];
    }

    public int getDieNumber()
    {
        return dieNumber;
    }
}
