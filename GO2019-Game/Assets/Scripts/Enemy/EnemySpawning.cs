using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    public GameObject enemyPrefab;

    private LevelGeneration levelGeneration;

    // Start is called before the first frame update
    void Start()
    {
        levelGeneration = FindObjectOfType<LevelGeneration>();
    }

    // Update is called once per frame
    void Update()
    {
        if(levelGeneration.stoppedGeneration){
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
