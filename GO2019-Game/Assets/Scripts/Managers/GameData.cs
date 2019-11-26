using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public float volume;
    public float sensitivity;
    public float brightness;
    public bool invertYAxis;
    public int floorNumber;

    public GameData (){
        volume = GameManager.soundFloat;
        sensitivity = GameManager.mouseSensitivity;
        invertYAxis = GameManager.invertedY;
        brightness = GameManager.brightness;
        floorNumber = GameManager.floorNumber;
    }
}
