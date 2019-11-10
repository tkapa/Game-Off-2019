using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSwapping : MonoBehaviour
{
    public bool tileLocked = false;

    private GameObject player;
    private LevelGeneration levelGeneration;

    private void Start() {
        levelGeneration = FindObjectOfType<LevelGeneration>();
    }

    private void Update() {
        if(player == null && FindObjectOfType<PlayerMovement>()){
            player = FindObjectOfType<PlayerMovement>().gameObject;
            Debug.Log("Found Player");
        }
    }

    private void OnBecameInvisible() {
        if(!tileLocked){
            var rand = Random.Range(0, levelGeneration.rooms.Length);
            GameObject newRoom = (GameObject)Instantiate(levelGeneration.rooms[rand], transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}
