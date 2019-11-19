using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameObject : InteractableObject
{
    public override void ObjectInteraction(){
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Menu");   
    }
}
