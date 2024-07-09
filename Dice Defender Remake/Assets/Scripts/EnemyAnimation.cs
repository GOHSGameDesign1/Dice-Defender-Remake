using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    public Animator spriteAnimator;
    public Animator dieAnimator;
    private DieNumber dieNumber;

    private int counter;

    private void Awake()
    {
        dieNumber = GetComponent<DieNumber>();
    }

    private void OnEnable()
    {
        dieAnimator.Play(("Enemy_Die" + dieNumber.getDieNumber()), -1, 0f);
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnimateMove()
    {
        if (spriteAnimator == null) return;
        spriteAnimator.StopPlayback();
        counter++;
        counter %= 2;
        spriteAnimator.Play("Enemy_Walk" + (counter+1), -1, 0f);
    }
}
