using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera: MonoBehaviour
{

    public Transform target;
    public float smoothing = 5f;

    Vector3 offset;

    void Start()
    {
        offset = transform.position - target.position;
    }

    void  Update()
    {
        Vector3 targetCameraPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position,
            targetCameraPos, smoothing * Time.deltaTime);
    }

}