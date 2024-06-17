using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShoot : MonoBehaviour
{
    private Slot slot;

    private void Awake()
    {
        slot = transform.GetChild(1).GetComponent<Slot>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (slot.currentDie == null) return;

            Debug.Log("Shooting Die: " +  slot.currentDie.getDieNumber());
            slot.DestroyDie();
        }
    }
}
