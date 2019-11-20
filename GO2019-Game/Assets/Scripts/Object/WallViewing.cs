using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallViewing : MonoBehaviour
{

    // Update is called once per frame
    void FixedUpdate()
    {

        gameObject.transform.LookAt(new Vector3(0, GameObject.FindGameObjectWithTag("Player").transform.localPosition.y -5, 0));
    }
}
