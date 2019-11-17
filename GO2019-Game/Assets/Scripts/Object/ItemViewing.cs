using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemViewing : MonoBehaviour
{

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(new Vector3(GameObject.FindGameObjectWithTag("Player").transform.position.x, transform.position.y, GameObject.FindGameObjectWithTag("Player").transform.position.z));
    }
}
