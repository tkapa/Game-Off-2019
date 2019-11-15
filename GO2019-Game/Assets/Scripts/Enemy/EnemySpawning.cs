using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    public GameObject enemyPrefab;

    // Update is called once per frame
    void Update()
    {
        if(LevelGeneration.stoppedGeneration){
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
