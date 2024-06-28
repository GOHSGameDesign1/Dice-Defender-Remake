using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointVFXAnim : MonoBehaviour
{
    private Animator animator;
    private AnimatorStateInfo info;

    private void Awake()
    {
        animator = transform.GetChild(0).GetComponent<Animator>();
        info = animator.GetCurrentAnimatorStateInfo(0);
    }


    // Update is called once per frame
    void Update()
    {

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.identity, 0.5f * Time.deltaTime);

        // When animation for the state has finished playing, destroy itself
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            Destroy(gameObject);
        }
    }
}
