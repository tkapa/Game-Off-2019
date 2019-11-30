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
    public Slider brightnessSlider;

    private void Start() {
        InitializeOptions();
    }

    public void InitializeOptions(){
        soundSlider.value = GameManager.soundFloat;
        AudioListener.volume = GameManager.soundFloat;

        brightnessSlider.value = GameManager.brightness;
        RenderSettings.ambientLight = new Color(GameManager.brightness, GameManager.brightness, GameManager.brightness, 1);

        sensitivitySlider.value = GameManager.mouseSensitivity;
        invertYToggle.isOn = GameManager.invertedY; 
    }

    public void SoundController(float val)
    {
        GameManager.soundFloat = val;
        AudioListener.volume = GameManager.soundFloat;
    }

    public void ToggleInvertedY(bool val){
        GameManager.invertedY = val;
    }

    public void SensitivityController(float val){
        GameManager.mouseSensitivity = val;
    }

    public void BrightnessController(float val){
        RenderSettings.ambientLight = new Color(val, val, val, 1);
        GameManager.brightness = val;
    }
}
