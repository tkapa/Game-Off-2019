using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public class GameManager : MonoBehaviour
{
    public static float soundFloat;
    public static bool invertedY;
    public static float mouseSensitivity;

    private static GameManager gameManagerInstance;
    
    void Awake(){
        DontDestroyOnLoad (this);
            
        if (GameManager.gameManagerInstance == null) {
            gameManagerInstance = this;
        } else {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        DefaultSettings();
        DontDestroyOnLoad(this.gameObject);
    }

    void DefaultSettings()
    {
        soundFloat = 1f;
        invertedY = false;
        mouseSensitivity = 1f;
    }
}
