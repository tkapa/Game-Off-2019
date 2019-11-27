using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningWall : MonoBehaviour
{
    public GameObject wall = null;

    private void OnTriggerExit(Collider other) {
        //Put wall moving sound effect here.
        wall.SetActive(true);
        Destroy(this);
    }
}
