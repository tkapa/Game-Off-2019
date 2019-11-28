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
    public AudioClip[] walkingFootsteps;
    public AudioClip[] runningFootsteps;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    
    public KeyCode sprintInput = KeyCode.LeftShift;

    CharacterController controller;
    PlayerUIManager playerUIManager;

    AudioSource audioSource;
     private float nextActionTime = 0.0f;
     public float period = 0.1f;
    Vector3 velocity;

    bool isGrounded;
    bool isSprinting;

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
        } else  if (!isGrounded){
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }

        /*while(!isSprinting && (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Vertical") > 0))
        {
            //StartCoroutine(WalkingFootsteps());
        }
        while(isSprinting)
        {
            //RunningFootsteps();
        }*/
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);  
    }

    IEnumerator WalkingFootsteps()
    {
        audioSource.PlayOneShot(walkingFootsteps[0], audioSource.volume);
        yield return new WaitForSeconds(0.1f);
        audioSource.PlayOneShot(walkingFootsteps[1], audioSource.volume);
        yield return new WaitForSeconds(0.1f);
    }

    void RunningFootsteps()
    {

    }
}
