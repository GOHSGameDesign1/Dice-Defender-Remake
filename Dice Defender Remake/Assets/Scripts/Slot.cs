using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public DieNumber currentDie { get; private set; }
    private Collider2D trigger;

    private void Awake()
    {
        trigger = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddDie(DieNumber die)
    {
        if(currentDie != null)
        {
            Debug.LogWarning("This slot already has a die in it!");
            return;
        }

        currentDie = die;

        currentDie.transform.position = transform.position;

        trigger.enabled = false;

        Debug.Log("die added: " + die.getDieNumber());
        
    }

    public void RemoveDie()
    {
        currentDie = null;
        trigger.enabled = true;
    }

    public void DestroyDie()
    {
        if(currentDie == null)
        {
            Debug.LogWarning("No Die to Destroy!");
            return;
        }

        Destroy(currentDie.gameObject);
        RemoveDie();
    }
}
