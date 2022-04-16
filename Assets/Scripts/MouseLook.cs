using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sens;

    public Transform cam;

    float xTilt;
    float yTilt;
    float zTilt;

    float mouseX;
    float mouseY;

    float xRotation;
    float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");

        yRotation += mouseX * sens;
        xRotation -= mouseY * sens;

        xRotation = Mathf.Clamp(xRotation, -90f - yTilt, 90f - yTilt);

        cam.rotation = Quaternion.Euler(xRotation + yTilt, yRotation + xTilt, zTilt);
    }
}
