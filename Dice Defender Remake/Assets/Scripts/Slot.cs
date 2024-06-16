using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public Transform currentDie { get; private set; }
    private Collider2D trigger;

    private void Awake()
    {
        trigger = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddDie(Transform die)
    {
        if(currentDie != null)
        {
            Debug.LogWarning("This slot already has a die in it!");
            return;
        }

        currentDie = die;

        currentDie.position = transform.position;

        trigger.enabled = false;
        
    }

    public void RemoveDie()
    {
        currentDie = null;
        trigger.enabled = true;
    }
}
