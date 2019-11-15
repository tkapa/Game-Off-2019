using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableObject : InteractableObject
{
    public override void ObjectInteraction(Transform handTransform){     
        StartCoroutine(LerpToHand(handTransform));
        transform.parent = handTransform.transform;
    }

    public void UseObject(){
        Debug.Log(gameObject.name + " Used");
        Destroy(gameObject);
    }

    IEnumerator LerpToHand(Transform handTransform){

        while(transform.position != handTransform.position){
            Vector3 newPos = Vector3.Lerp(transform.position, handTransform.position, Time.deltaTime * 10);
            transform.position = newPos;
            yield return null;
        }
    }
}
