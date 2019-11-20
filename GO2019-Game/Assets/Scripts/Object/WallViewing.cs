using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallViewing : MonoBehaviour
{

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(new Vector3(transform.localPosition.x, GameObject.FindGameObjectWithTag("Player").transform.localPosition.y, transform.localPosition.z));
    }
}
