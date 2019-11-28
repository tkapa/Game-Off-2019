using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningWall : MonoBehaviour
{
    public GameObject wall = null;
    public WallShiftingSound shiftingSound = null;

    private void Start() {
        if(GetComponentInChildren<WallShiftingSound>()){
            shiftingSound = GetComponentInChildren<WallShiftingSound>();
        }
    }

    private void OnTriggerExit(Collider other) {
        //Put wall moving sound effect here.
        shiftingSound.PlaySound();
        wall.SetActive(true);
        Destroy(this);
    }
}
