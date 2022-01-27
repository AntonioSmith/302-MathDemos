using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCameraRig : MonoBehaviour
{
    public Transform thingToLookAt;

    private float pitch = 0;
    private float yaw = 0;
    private float dis = 10;

    public float mouseSensitivityX = 1;
    public float mouseSensitivityY = 1;
    public float scrollSensitivity = 1;

    public Camera cam;

    void Start()
    {

    }

    void LateUpdate()
    {
        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");

        yaw += mx * mouseSensitivityX;
        pitch -= my * mouseSensitivityY;
        pitch = Mathf.Clamp(pitch, -89, 89); // Stop the camera from pitching more the 90degrees up or down

        transform.rotation = Quaternion.Euler(pitch, yaw, 0);

        // Zoom
        Vector2 scrollAmt = Input.mouseScrollDelta;
        dis += scrollAmt.y * scrollSensitivity;
        dis = Mathf.Clamp(dis, 5, 50);

        float z = AnimMath.Ease(cam.transform.localPosition.z, -dis, .01f);

        cam.transform.localPosition = new Vector3(0, 0, z);

        // Position
        if (thingToLookAt == null) return;
        //transform.position = thingToLookAt.position;

        transform.position = AnimMath.Ease(transform.position, thingToLookAt.position, .001f);
    }
}
