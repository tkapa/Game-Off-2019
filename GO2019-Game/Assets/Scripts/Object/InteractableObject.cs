using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public virtual void ObjectInteraction(){
        Debug.Log("Interacted with:" + this.gameObject.name);
    }

    public virtual void ObjectInteraction(Transform position){
        Debug.Log("Interacted with:" + this.gameObject.name + " " + position);
    }
}
