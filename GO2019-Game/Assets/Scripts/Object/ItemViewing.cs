using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemViewing : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
    }
}
