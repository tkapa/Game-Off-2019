using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableObject : InteractableObject
{
    public bool isPlaceable = false;

    public override void ObjectInteraction(Transform handTransform){     
        transform.position = handTransform.position;
        transform.parent = handTransform;
        transform.rotation = handTransform.rotation;
    }

    public virtual void UseObject(){
        Debug.Log(gameObject.name + " Used");
        Destroy(gameObject);
    }

    public virtual void PlaceObject(Vector3 placePosition){
        transform.parent = null;
        transform.position = placePosition;
    }

    /*
    IEnumerator LerpToPosition(Vector3 newPosition){

        while(transform.position != newPosition){
            Vector3 newPos = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * 10);
            transform.position = newPos;
            yield return null;
        }
    }*/
}
