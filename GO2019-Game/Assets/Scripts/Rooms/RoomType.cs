using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomType : MonoBehaviour
{
    public int type;
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

    public void RoomDestruction(){
        Destroy(this.gameObject);
    }

    private void OnBecameInvisible() {
        if(!tileLocked){
            var rand = Random.Range(0, levelGeneration.rooms.Length);
            Instantiate(levelGeneration.rooms[rand], transform.position, Quaternion.identity);

            RoomDestruction();
        }
    }
}
