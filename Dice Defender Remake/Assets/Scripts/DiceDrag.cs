using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceDrag : MonoBehaviour, IDraggable
{
    bool gettingDragged;
    Vector2 mousePos;
    Vector2 dragOffset;

    private HashSet<Slot> slotsInRange = new HashSet<Slot>();
    private Slot currentSlot;

    private DieNumber dieNumber;


    private void Awake()
    {
        dieNumber = GetComponent<DieNumber>();
        gettingDragged = false;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (gettingDragged) transform.position = mousePos + dragOffset;
    }

    public void OnClick()
    {
        gettingDragged=true;
        dragOffset = (Vector2)transform.position - mousePos;
        
        if(currentSlot != null )
        {
            currentSlot.RemoveDie();
        }

        currentSlot = null;
    }

    public void OnEndClick()
    {
        gettingDragged = false;

        Slot[] slots = new Slot[slotsInRange.Count];
        slotsInRange.CopyTo(slots);

        if (slotsInRange.Count == 1)
        {

            currentSlot = slots[0];
            slots[0].AddDie(dieNumber); 
        }

        if(slotsInRange.Count > 1) 
        {
            currentSlot = DetermineClosest(slots);
            currentSlot.AddDie(dieNumber);
        }
    }

    Slot DetermineClosest(Slot[] slots)
    {
        Vector2 distance = transform.position - slots[0].transform.position;
        float minDistance = distance.magnitude;
        Slot minSlot = slots[0];
        foreach (Slot slot in slots)
        {
            distance = transform.position - slot.transform.position;
            if(distance.magnitude < minDistance)
            {
                minDistance = distance.magnitude;
                minSlot = slot;
            }
        }

        return minSlot;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Slot slot)){
            slotsInRange.Add(slot);
            Debug.Log("added Transform. Total: " + slotsInRange.Count);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Slot slot))
        {
            slotsInRange.Remove(slot);
        }
    }
}
