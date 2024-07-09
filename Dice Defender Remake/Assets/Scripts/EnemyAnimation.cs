using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    public Animator spriteAnimator;
    public Animator dieAnimator;
    public float VFXSpawnOffset;

    private DieNumber dieNumber;
    private GameObject walkVFX;

    private int counter;

    private void Awake()
    {
        dieNumber = GetComponent<DieNumber>();
        walkVFX = (GameObject)Resources.Load("Prefabs/Enemy Move VFX");
    }

    private void OnEnable()
    {
        if (dieAnimator != null)
        {
            dieAnimator.Play(("Enemy_Die" + dieNumber.getDieNumber()), -1, 0f);
        }
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (dieAnimator)
        {
            dieAnimator.Play(("Enemy_Die" + dieNumber.getDieNumber()));
        }
    }

    public void AnimateMove()
    {
        if (spriteAnimator == null) return;
        spriteAnimator.StopPlayback();
        counter++;
        counter %= 2;
        spriteAnimator.Play("Enemy_Walk" + (counter+1), -1, 0f);

        if(walkVFX != null)
        {
            Instantiate(walkVFX, transform.position + Vector3.right * VFXSpawnOffset, Quaternion.identity);
        }
    }
}
