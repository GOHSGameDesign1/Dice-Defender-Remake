using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DiceDrag : MonoBehaviour, IDraggable
{
    bool gettingDragged;
    Vector2 mousePos;
    Vector2 dragOffset;

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

        if(TryGetComponent(out DieSpawnAnimation dieAnim))
        {
            dieAnim.fixRotation();
        }
        
        if(currentSlot != null )
        {
            currentSlot.RemoveDie();
        }

        currentSlot = null;
    }

    public void OnEndClick()
    {
        gettingDragged = false;

        if (currentSlot != null)
        {
            currentSlot.RemoveDie();
        }

        currentSlot = null;

        Slot[] slots = GetCloseSlots();
        

        if (slots.Length == 1)
        {

            currentSlot = slots[0];
            slots[0].AddDie(dieNumber); 
        }

        if(slots.Length > 1) 
        {
            currentSlot = DetermineClosest(slots);
            currentSlot.AddDie(dieNumber);
        }
    }

    public void OnRightClick()
    {
        OnEndClick();
    }

    Slot[] GetCloseSlots()
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, 0.87f);
        List<Slot> slots = new List<Slot>();
        foreach (Collider2D col in cols)
        {
            if(col.transform.TryGetComponent(out Slot slot))
            {
                slots.Add(slot);
            }
        }
        Slot[] ret = new Slot[slots.Count];
        ret = slots.ToArray();
        return ret;
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
}
