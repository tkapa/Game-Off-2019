using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{

    [SerializeField]
    GameObject[] consumables = null;

    [SerializeField]
    private GameObject spawnerLocation = null;

    public GameObject chosenItem = null;    

    // Start is called before the first frame update
    void Start()
    {
        SpawnItem();
    }

    void SpawnItem()
    {
        GameObject item = (GameObject)Instantiate(consumables[Random.Range(0, consumables.Length)], spawnerLocation.transform.position, spawnerLocation.transform.rotation);
        
        item.transform.parent = this.transform;
        
    }
}
