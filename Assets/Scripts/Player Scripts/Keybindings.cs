using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Keybindings : MonoBehaviour
{
    [Header("InputActions")]
    public InputAction movementControlls;
    public InputAction sprintButton;
    public InputAction jump;

    protected bool isJumping;
    protected bool isRunning;

    void Awake()
    {
        movementControlls.performed += OnMovement;
        movementControlls.canceled += OnMovement;
        sprintButton.performed += OnSprint;
        sprintButton.canceled += OnSprint;
        jump.performed += OnJump;
        jump.canceled += OnJump;
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
        Debug.Log("Is Moving");
    }

    private void OnEnable()
    {
        movementControlls.Enable();
        sprintButton.Enable();
        jump.Enable();
    }

    private void OnDisable()
    {
        movementControlls.Disable();
        sprintButton.Disable();
        jump.Disable();
    }
}
