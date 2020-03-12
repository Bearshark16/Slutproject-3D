using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Networking;

public class PlayerController3D : NetworkBehaviour
{
    public CharacterController controller;
    public GameObject userInterface;
    public float walkingSpeed = 10f;
    public float runningSpeed = 15f;
    public float jumpHeight = 3f;
    public float gravity = -9.81f;

    private Vector3 velocity;
    private bool isGrounded;
    private bool hasReleasedJump = true;
    private Keybindings keybindings;

    private void Awake()
    {
        if (!isLocalPlayer) 
        {
            
            //this.GetComponent<Target>().enabled = false;
        }
        keybindings = this.GetComponent<Keybindings>();
    }

    // Update is called once per frame
    void Update()
    {

        if(!isLocalPlayer) 
        {
            this.GetComponentInChildren<Camera>().enabled = false;
            this.GetComponent<PlayerController3D>().enabled = false;
            this.GetComponent<CameraRotation>().enabled = false;
            this.GetComponent<ObjectInteraction>().enabled = false;
            this.GetComponent<Keybindings>().enabled = false;
            userInterface.SetActive(false);
            return;
        }

        if (keybindings.isRunning)
        {
            CmdMove(controller, keybindings.direction.x, keybindings.direction.y, runningSpeed, jumpHeight, gravity, keybindings.isJumping);
        }
        else
        {
            CmdMove(controller, keybindings.direction.x, keybindings.direction.y, walkingSpeed, jumpHeight, gravity, keybindings.isJumping);
        }
    }

    public void CmdMove(CharacterController controller, float x, float z, float speed, float jumpHeight, float gravity, bool isJumping)
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
            velocity.y = CmdJump(jumpHeight, gravity);
            hasReleasedJump = false;
        }
        else if (!isJumping)
        {
            hasReleasedJump = true;
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    private float CmdJump(float height, float pull)
    {
        float value = Mathf.Sqrt(height * -2 * pull);

        return value;
    }
}
