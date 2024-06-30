using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieShadow : MonoBehaviour
{
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.parent.GetChild(0).position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = transform.parent.GetChild(0).rotation;
        transform.position = transform.parent.GetChild(0).position - offset;
    }
}
