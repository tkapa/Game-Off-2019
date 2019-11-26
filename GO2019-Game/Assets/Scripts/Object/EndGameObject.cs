using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameObject : InteractableObject
{
    public override void ObjectInteraction(){
        GameManager.floorNumber++;
        SceneManager.LoadScene("Generation Testing");   
    }
}
