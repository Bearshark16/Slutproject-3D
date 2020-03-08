using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController3D : Keybindings
{
    public CharacterController controller;
    public float walkingSpeed = 10f;
    public float runningSpeed = 15f;
    public float jumpHeight = 3f;
    public float gravity = -9.81f;

    private Vector2 direction;
    private Vector3 velocity;
    private bool isGrounded;
    private bool hasReleasedJump = true;

    public override void OnMovement(InputAction.CallbackContext ctx)
    {
        direction = ctx.ReadValue<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning) 
        {
            Move(controller, direction.x, direction.y, runningSpeed, jumpHeight, gravity, isJumping);
        }
        else 
        {
            Move(controller, direction.x, direction.y, walkingSpeed, jumpHeight, gravity, isJumping);
        } 
    }

    public void Move(CharacterController controller, float x, float z, float speed, float jumpHeight, float gravity, bool isJumping) 
    {
        isGrounded = controller.isGrounded;
        Debug.Log("isGrounded: " + isGrounded);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        Vector3 movement = (x * controller.transform.right + z * controller.transform.forward) * speed * Time.deltaTime;

        controller.Move(movement);

        if (isJumping && isGrounded && hasReleasedJump) 
        {
            velocity.y = Jump(jumpHeight, gravity);
            hasReleasedJump = false;
        }
        else if (!isJumping)
        {
            hasReleasedJump = true;
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
    private float Jump(float height, float pull) 
    {
        float value = Mathf.Sqrt(height * -2 * pull);

        return value;
    }
}
