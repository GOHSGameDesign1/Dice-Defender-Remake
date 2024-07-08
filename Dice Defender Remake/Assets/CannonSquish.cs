using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonSquish : MonoBehaviour
{

    private Animator animator;

    private const string CANNON_IDLE = "Cannon_Idle";
    private const string CANNON_SHOOT = "Cannon_Shoot";

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Squish()
    {
        animator.StopPlayback();
        animator.Play(CANNON_SHOOT, -1, 0);
    }

    private void OnEnable()
    {
        CannonShoot.onShoot += Squish;
    }

    private void OnDisable()
    {
        CannonShoot.onShoot -= Squish;
    }
}
