﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static float soundFloat;
    public static bool invertedY;
    public static float mouseSensitivity;

    public static GameManager gameManagerInstance;
    
    void Awake(){
        
        DontDestroyOnLoad (this);
            
        if (GameManager.gameManagerInstance == null) {
            gameManagerInstance = this;
        } else {
            Destroy(this.gameObject);
        }
    }

    void DefaultSettings()
    {
        soundFloat = 1f;
        invertedY = false;
        mouseSensitivity = 1f;
    }

    public void SaveGameData(){
        SaveLoadManager.SaveGameData();
    }

    public void LoadGameData(){
        GameData data = SaveLoadManager.LoadGameData();

        if(data == null){
            DefaultSettings();
        } else {
            soundFloat = data.volume;
            mouseSensitivity = data.sensitivity;
            invertedY = data.invertYAxis;
        }
    }
}
