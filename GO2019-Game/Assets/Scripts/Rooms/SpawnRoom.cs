using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoom : MonoBehaviour
{
    private LevelGeneration levelGeneration;

    private void Start() {
        levelGeneration = FindObjectOfType<LevelGeneration>();    
    }

    // Update is called once per frame
    void Update()
    {
        if(levelGeneration.stoppedGeneration){
            Collider[] roomDetector = Physics.OverlapSphere(transform.position, 0.1f, LayerMask.GetMask("Ground"));
            if(roomDetector.Length == 0){
                int rand = Random.Range(0, levelGeneration.rooms.Length);
                Instantiate(levelGeneration.rooms[rand], transform.position, Quaternion.identity);
                Destroy(this);
            }  
        }              
    }
}
