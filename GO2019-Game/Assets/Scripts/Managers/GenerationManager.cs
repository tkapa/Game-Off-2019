using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationManager : MonoBehaviour
{
    [SerializeField]private Vector2 layoutSize = new Vector2(10,10);
    [SerializeField]private GameObject[] tileArray;
    [SerializeField]private Vector2 tileSize = new Vector2(2, 2);
    
    // Start is called before the first frame update
    void Start()
    {
        GenerateMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateMap(){
        for(int x = 0; x < layoutSize.x; x++){
            for(int y = 0; y<layoutSize.y; y++){
                var tileIndex = (int)Mathf.Floor(Random.Range(0, tileArray.Length));
                Vector3 spawnPosition = new Vector3((x*tileSize.x), 0, (y*tileSize.y));
                Debug.Log(tileIndex);                

                Instantiate(tileArray[tileIndex], spawnPosition, Quaternion.identity);
            }
        }
    }
}
