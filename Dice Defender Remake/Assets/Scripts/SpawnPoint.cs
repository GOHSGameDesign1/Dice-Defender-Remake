using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public bool isTouching { get; private set; }

    private void Start()
    {
        isTouching = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        isTouching=true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isTouching=false;
    }
}
