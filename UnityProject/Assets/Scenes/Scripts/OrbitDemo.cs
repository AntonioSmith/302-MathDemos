using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitDemo : MonoBehaviour
{
    public Transform orbitCenter;

    public float radius = 10;

    void Update()
    {
        if (!orbitCenter) return; 

        float x = radius * Mathf.Cos(Time.time);
        float z = radius * Mathf.Sin(Time.time);

        transform.position = new Vector3(x, 0, z) + orbitCenter.position;
    }
}
