using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GodMode : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
            KillPlayer();

        if(Input.GetKeyDown(KeyCode.P))
            NextLevel();
    }

    void KillPlayer(){
        if(TryGetComponent<PlayerUIManager>(out PlayerUIManager compo)){
            compo.TakeDamage(99999999f);
        }
    }

    void NextLevel(){
        GameManager.floorNumber++;
        SceneManager.LoadScene("Generation Testing"); 
    }
}
