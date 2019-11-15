using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnPoint : MonoBehaviour
{
    public GameObject playerPrefab;

    // Update is called once per frame
    void Update()
    {
        if(LevelGeneration.stoppedGeneration){
            Debug.Log("Player Spawned");
            Instantiate(playerPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
