using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;
    public float sprintSpeed = 12f; 
    public float gravity = -9.81f;

    public float sprintFOV;
    public float regularFOV;
    public AudioClip[] footstepSounds;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    
    public KeyCode sprintInput = KeyCode.LeftShift;

    CharacterController controller;
    PlayerUIManager playerUIManager;

    AudioSource audioSource;
    Vector3 velocity;

    bool isGrounded;
    bool isSprinting = false;
    bool isMoving = false;

    float moveX = 0f;
    float moveZ = 0f;

    private void Start() {
        controller = GetComponent<CharacterController>();
        playerUIManager = GetComponent<PlayerUIManager>();
        Camera.main.fieldOfView = regularFOV;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update() {
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");

        if((moveX != 0 || moveZ != 0) && !isMoving){
            isMoving = true;
            StartCoroutine(FootSteps());
        } else if(moveX == 0f && moveZ == 0f){
            isMoving = false;
            StopCoroutine(FootSteps());
        }

        if(Input.GetKeyDown(sprintInput)){
            isSprinting = true;
        } else if (Input.GetKeyUp(sprintInput)){
            isSprinting = false;            
        }

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        
        if(isSprinting && playerUIManager.playerStamina > 0){
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, sprintFOV, Time.deltaTime * 5);
            controller.Move(move * sprintSpeed * Time.deltaTime);
            playerUIManager.LoseStamina();
        } else {
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, regularFOV, Time.deltaTime * 5);
            controller.Move(move * speed * Time.deltaTime);            
            playerUIManager.GainStamina();
            isSprinting = false;
        }

        if(isGrounded && velocity.y < 0){
            velocity.y = -2f;
        } else if (!isGrounded){
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);  
    }

    IEnumerator FootSteps()
    {
        while(isMoving){
            int rand = Random.Range(0, footstepSounds.Length);

            if(!isSprinting){
                audioSource.pitch = 1;
                audioSource.PlayOneShot(footstepSounds[rand]); 
                yield return new WaitForSeconds(0.75f);              
            } else{
                audioSource.pitch = 1.5f;
                audioSource.PlayOneShot(footstepSounds[rand]); 
                yield return new WaitForSeconds(0.4f); 
            }            
        }
    }
}
