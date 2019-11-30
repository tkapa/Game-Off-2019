﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroPlayerSpawn : MonoBehaviour
{
    public GameObject playerPrefab = null;
    
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
