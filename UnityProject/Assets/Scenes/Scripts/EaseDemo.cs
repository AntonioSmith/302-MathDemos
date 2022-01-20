using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EaseDemo : MonoBehaviour
{
    public Transform target;
    public float percentLeftAfter1second = .0001f;

    void Start()
    {
        
    }

    void Update()
    {
        // wrong way to do Easing
        //transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime);

        transform.position = AnimMath.Ease(transform.position, target.position, percentLeftAfter1second, Time.deltaTime);
    }
}
