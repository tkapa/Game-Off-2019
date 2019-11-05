using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 12f;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    
    CharacterController controller;
    Vector3 velocity;
    bool isGrounded;
    float moveX = 0f;
    float moveZ = 0f;

    private void Start() {
        controller = GetComponent<CharacterController>();
    }

    private void Update() {
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * speed * Time.deltaTime);

        if(isGrounded && velocity.y < 0){
            velocity.y = -2f;
        } else  if (!isGrounded){
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
    }
}
