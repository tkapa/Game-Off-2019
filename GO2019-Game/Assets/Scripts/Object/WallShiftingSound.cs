using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallShiftingSound : MonoBehaviour
{
    public AudioSource source;

    public void PlaySound(){
        if(!source.isPlaying){
            source.pitch = Random.Range(-1.5f, 1.5f);
            source.PlayOneShot(source.clip);
        }
    }
}
