using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightCameraRig : MonoBehaviour
{
    public float speed = 10;
    private float pitch = 0;
    private float yaw = 0;
    public float mouseSensitivityX = 1;
    public float mouseSensitivityY = 1;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float v = Input.GetAxis("Vertical"); // Forward / Back
        float h = Input.GetAxis("Horizontal"); // Left / Right

        Vector3 dir = transform.forward * v + transform.right * h; // Calculates direction moved
        if (dir.magnitude > 1) dir.Normalize(); // Fixes speed when moving diagonally to not go faster
        transform.position += dir * Time.deltaTime * speed; // Moves the player

        // Update Rotation
        float mx = Input.GetAxis("Mouse X"); // Yaw (Left/Right)
        float my = Input.GetAxis("Mouse Y"); // Pitch (Up/Down)

        yaw += mx * mouseSensitivityX; 
        pitch -= my * mouseSensitivityY;

        pitch = Mathf.Clamp(pitch, -89, 89); // Stop the camera from pitching more the 90degrees up or down

        transform.rotation = Quaternion.Euler(pitch, yaw, 0);
    }
}
