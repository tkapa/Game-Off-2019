using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameObject : InteractableObject
{
    public override void ObjectInteraction(){
        Debug.Log("Ended the game");        
    }
}
