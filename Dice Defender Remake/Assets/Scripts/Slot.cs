using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public Transform currentDie { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        
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
    }

    public void RemoveDie()
    {
        currentDie = null;
    }
}
