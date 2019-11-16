using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;
    public float sprintSpeed = 12f; 
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    
    public KeyCode sprintInput = KeyCode.LeftShift;

    CharacterController controller;
    PlayerUIManager playerUIManager;
    Vector3 velocity;

    bool isGrounded;
    bool isSprinting;

    float moveX = 0f;
    float moveZ = 0f;

    private void Start() {
        controller = GetComponent<CharacterController>();
        playerUIManager = GetComponent<PlayerUIManager>();
    }

    private void Update() {
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");

        if(Input.GetKeyDown(sprintInput)){
            isSprinting = true;
        } else if (Input.GetKeyUp(sprintInput)){
            isSprinting = false;
        }

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        
        if(isSprinting && playerUIManager.playerStamina > 0){
            controller.Move(move * sprintSpeed * Time.deltaTime);
            playerUIManager.LoseStamina();
        } else {
            controller.Move(move * speed * Time.deltaTime);
            playerUIManager.GainStamina();
            isSprinting = false;
        }

        if(isGrounded && velocity.y < 0){
            velocity.y = -2f;
        } else  if (!isGrounded){
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);  
    }
}
