using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public float volume;
    public float sensitivity;
    public bool invertYAxis;

    public GameData (){
        volume = GameManager.soundFloat;
        sensitivity = GameManager.mouseSensitivity;
        invertYAxis = GameManager.invertedY;
    }
}
