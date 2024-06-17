using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShoot : MonoBehaviour
{
    private Slot slot;
    private Transform cannonSprite;

    public GameObject dieProj;

    private void Awake()
    {
        cannonSprite = transform.GetChild(0);
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
            ShootDie();
        }
    }

    void ShootDie()
    {
        GameObject proj = Instantiate(dieProj, transform.position, Quaternion.identity);
        proj.GetComponent<ProjectileFunction>().direction = cannonSprite.right;
        slot.DestroyDie();
    }
}
