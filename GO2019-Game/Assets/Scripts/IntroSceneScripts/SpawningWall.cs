using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningWall : MonoBehaviour
{
    public GameObject wall = null;

    private void OnTriggerExit(Collider other) {
        wall.SetActive(true);
        Destroy(this);
    }
}
