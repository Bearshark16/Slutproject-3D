using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Networking;

public class CameraRotation : NetworkBehaviour
{
    public Transform playerBody;
    public Camera playerCamera;
    public float sensitivity = 100f;

    float mouseX;
    float mouseY;
    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isLocalPlayer) 
        {
            return;
        }

        mouseX = Keybindings.instance.rotation.x;
        mouseY = Keybindings.instance.rotation.y;
        MouseLook();
    }

    private void MouseLook()
    {
        mouseX = mouseX * sensitivity * Time.deltaTime;
        mouseY = mouseY * sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
