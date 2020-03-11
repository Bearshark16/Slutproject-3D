using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Keybindings : MonoBehaviour
{
    public static Keybindings instance;

    public InputAction playerMovement;
    public InputAction playerRotation;
    public InputAction sprint;
    public InputAction jump;
    public InputAction fire;
    public InputAction interact;

    public bool isJumping;
    public bool isRunning;
    public bool isInteracting;
    public bool isFire;

    public Vector2 direction;
    public Vector2 rotation;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Multiple instances of Inventory are present! There shoud only be one instance of Inventory in a scene");
            return;
        }

        instance = this;

        playerMovement.performed += OnMovement;
        playerMovement.canceled += OnMovement;
        playerRotation.performed += OnMouseMovement;
        playerRotation.canceled += OnMouseMovement;
        sprint.performed += OnSprint;
        sprint.canceled += OnSprint;
        jump.performed += OnJump;
        jump.canceled += OnJump;
        fire.performed += OnFire;
        fire.canceled += OnFire;
        interact.performed += OnPickUp;
        interact.canceled += OnPickUp;
    }

    private void OnJump(InputAction.CallbackContext ctx)
    {
        var value = ctx.ReadValue<float>();
        if (value > 0)
        {
            isJumping = true;
        }
        else
        {
            isJumping = false;
        }
    }

    private void OnSprint(InputAction.CallbackContext ctx)
    {
        var value = ctx.ReadValue<float>();
        if (value > 0)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
    }

    public virtual void OnMovement(InputAction.CallbackContext ctx)
    {
        direction = ctx.ReadValue<Vector2>();
    }

    private void OnMouseMovement(InputAction.CallbackContext ctx)
    {
        rotation = ctx.ReadValue<Vector2>();
    }

    private void OnPickUp(InputAction.CallbackContext ctx)
    {
        var value = ctx.ReadValue<float>();
        if (value > 0)
        {
            isInteracting = true;
        }
        else
        {
            isInteracting = false;
        }
    }

    public void OnFire(InputAction.CallbackContext ctx)
    {
        var value = ctx.ReadValue<float>();
        if (value > 0)
        {
            isFire = true;
        }
        else
        {
            isFire = false;
        }
    }

    private void OnEnable()
    {
        playerMovement.Enable();
        playerRotation.Enable();
        sprint.Enable();
        jump.Enable();
        fire.Enable();
        interact.Enable();
    }

    private void OnDisable()
    {
        playerMovement.Disable();
        playerRotation.Disable();
        sprint.Disable();
        jump.Disable();
        fire.Disable();
        interact.Disable();
    }
}
