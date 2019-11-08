using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnPoint : MonoBehaviour
{
    public GameObject playerPrefab;
    LevelGeneration levelGeneration;

    // Start is called before the first frame update
    void Start()
    {
        levelGeneration = FindObjectOfType<LevelGeneration>();
    }

    // Update is called once per frame
    void Update()
    {
        if(levelGeneration.stoppedGeneration){
            Debug.Log("Player Spawned");
            Instantiate(playerPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
