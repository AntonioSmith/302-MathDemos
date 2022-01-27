using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    public Transform target;
    public float desiredDistance;

    void Start()
    {
        
    }

    void LateUpdate()
    {
        Vector3 vToTarget = target.position - transform.position;

        //Camera Position
        Vector3 targetPosition = -vToTarget;
        targetPosition.Normalize();
        targetPosition *= desiredDistance;

        targetPosition += target.position;

        transform.position = AnimMath.Ease(transform.position, target.position, .01f);

        // Turn to look at
        transform.rotation = Quaternion.LookRotation(vToTarget, Vector3.up);
    }
}
