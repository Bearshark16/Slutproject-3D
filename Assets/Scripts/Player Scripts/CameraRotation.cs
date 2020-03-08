using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRotation : MonoBehaviour
{
    public InputAction cameraRotation;
    public Transform playerBody;
    public Camera playerCamera;
    public float sensitivity = 100f;

    float mouseX;
    float mouseY;
    float xRotation = 0f;

    private void Awake()
    {
        cameraRotation.performed += OnMouseMovement;
        cameraRotation.canceled += OnMouseMovement;
    }

    private void OnMouseMovement(InputAction.CallbackContext ctx)
    {
        var value = ctx.ReadValue<Vector2>();
        mouseX = value.x;
        mouseY = value.y;
    }

    private void OnEnable()
    {
        cameraRotation.Enable();
    }

    private void OnDisable()
    {
        cameraRotation.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
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
