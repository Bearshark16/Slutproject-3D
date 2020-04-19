using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController3D : NetworkBehaviour
{
    public CharacterController controller;
    public Rigidbody rigidbody;
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
            this.GetComponentInChildren<AudioListener>().enabled = false;
            //this.GetComponent<PlayerController3D>().enabled = false;
            //this.GetComponent<CameraRotation>().enabled = false;
            //this.GetComponent<ObjectInteraction>().enabled = false;
            //this.GetComponent<Keybindings>().enabled = false;
            userInterface.SetActive(false);
            return;
        }

        keybindings = Keybindings.instance;

        if (keybindings.isRunning)
        {
            Move(keybindings.direction.x, keybindings.direction.y, runningSpeed);
        }
        else
        {
            Move(keybindings.direction.x, keybindings.direction.y, walkingSpeed);
        }
    }

    void Move(float horzontal, float vertical, float speed)
    {
        Vector3 movement = new Vector3(horzontal, 0, vertical) * Time.smoothDeltaTime * speed;

        Vector3 targetPosition = rigidbody.position + rigidbody.transform.TransformDirection(movement);

        rigidbody.MovePosition(targetPosition);
    }
}
