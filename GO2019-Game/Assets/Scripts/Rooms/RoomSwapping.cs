using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSwapping : MonoBehaviour
{
    public bool tileLocked = false;

    private GameObject player;
    private LevelGeneration levelGeneration;

    private bool canSwap = false;

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
    }

    private void OnBecameVisible() {
        canSwap = true;
    }

    private void OnBecameInvisible() {
        Debug.Log("Swapping Room");
        if(!tileLocked && canSwap){
            var rand = Random.Range(0, levelGeneration.rooms.Length);
            GameObject newRoom = (GameObject)Instantiate(levelGeneration.rooms[rand], transform.position, Quaternion.identity); 

            newRoom.GetComponent<RoomSwapping>().canSwap = false;
            Destroy(this.gameObject);
        }
    }
}
