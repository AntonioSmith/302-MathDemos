using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpDemo : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;

    //[Range(0, 1)] // makes the percent a slider in the inspector
    public float percent = 0;

    void DoInterpolation()
    {
        if (pointA == null) return;
        if (pointB == null) return;

        // Lerp on position
        Vector3 pos = Vector3.Lerp(pointA.position, pointB.position, percent);

        // Lerp on rotation
        Quaternion rot = Quaternion.Lerp(pointA.rotation, pointB.rotation, percent);

        transform.position = pos;
        transform.rotation = rot;
    }

    private void OnValidate()
    {
        DoInterpolation();
    }
}
