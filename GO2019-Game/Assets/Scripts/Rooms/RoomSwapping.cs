using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSwapping : MonoBehaviour
{
    public bool tileLocked = false;
    private GameObject player;
    LevelGeneration levelGeneration;

    private bool canSwap = false;
    private bool playerSeen = false;

    private float swapBufferTime = 0.5f;
    private float swapBufferTimer = 0f;

    private void Start() {
        levelGeneration = FindObjectOfType<LevelGeneration>();
    }

    private void Update() {   
        if(player == null && FindObjectOfType<PlayerMovement>()){
            player = FindObjectOfType<PlayerMovement>().gameObject;
        }

        if(player != null){
            float playerDist = Vector3.Distance(transform.position, player.transform.position);
            if(playerDist > 20 || playerDist < 7){
                canSwap = false;
            }
        }  
        
        if(canSwap){
            swapBufferTimer += Time.deltaTime;
        } else if(!canSwap){
            swapBufferTimer = 0f;
        }

        if(!tileLocked && playerSeen && swapBufferTimer >= swapBufferTime){
                var rand = Random.Range(0, levelGeneration.rooms.Length);
                GameObject newRoom = (GameObject)Instantiate(levelGeneration.rooms[rand], transform.position, Quaternion.identity); 

                newRoom.GetComponent<RoomSwapping>().canSwap = false;
                Destroy(this.gameObject);
            }  
    }

    private void OnBecameVisible() {
        playerSeen = true;
        canSwap = false;
    }

    private void OnBecameInvisible() {
        canSwap = true;
    }
}
