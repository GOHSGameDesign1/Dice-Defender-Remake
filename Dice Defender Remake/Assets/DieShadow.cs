using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieShadow : MonoBehaviour
{
    Vector3 offset;
    public Transform followTransform;

    // Start is called before the first frame update
    void Start()
    {

        offset = followTransform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = followTransform.rotation;
        transform.position = followTransform.position - offset;
    }
}
