using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Transform player;

    public float mouseSensitivity = 65f;

    public float xRotation;

    private float mouseX, mouseY;

    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime * 15;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime * 10;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -45f, 45f);

        player.Rotate(Vector3.up * mouseX);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}