using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController3D : MonoBehaviour
{
    public CharacterController controller;
    public float walkingSpeed = 10f;
    public float runningSpeed = 15f;
    public float jumpHeight = 3f;
    public float gravity = -9.81f;

    private float gravityMultiplier = -9.81f;

    private Vector3 velocity;
    private bool isGrounded;
    private bool hasReleasedJump = true;

    // Update is called once per frame
    void Update()
    {
        if (Keybindings.instance.isRunning) 
        {
            Move(controller, Keybindings.instance.direction.x, Keybindings.instance.direction.y, runningSpeed, jumpHeight, gravity, Keybindings.instance.isJumping);
        }
        else 
        {
            Move(controller, Keybindings.instance.direction.x, Keybindings.instance.direction.y, walkingSpeed, jumpHeight, gravity, Keybindings.instance.isJumping);
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
        float value = Mathf.Sqrt(height * -2 * pull * gravityMultiplier);

        return value;
    }
}
