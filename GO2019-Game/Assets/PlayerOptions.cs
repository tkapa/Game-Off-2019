using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerOptions : MonoBehaviour
{
    [Header("Options")]    
    public Slider soundSlider;
    public Toggle invertYToggle;
    public Slider sensitivitySlider;

    // Start is called before the first frame update
    void Start()
    {   
        soundSlider.value = GameManager.soundFloat;
        sensitivitySlider.value = GameManager.mouseSensitivity;
        invertYToggle.isOn = GameManager.invertedY;       
    }

    public void SoundController()
    {
        GameManager.soundFloat = soundSlider.value;
        AudioListener.volume = GameManager.soundFloat;
    }

    public void ToggleInvertedY(){
        GameManager.invertedY = invertYToggle.isOn;
    }

    public void SensitivityController(){
        GameManager.mouseSensitivity = sensitivitySlider.value;
    }
}
