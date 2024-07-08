using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveVFX : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
        {
            Destroy(gameObject);
        }
    }
}
