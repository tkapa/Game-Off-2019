﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{

    [Header("Options")]
    public Slider soundSlider;
    public Toggle invertYToggle;
    public Slider sensitivitySlider;

    public void Start() 
    {
        soundSlider.value = GameManager.soundFloat;
        invertYToggle.isOn = GameManager.invertedY;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Testing Scene");
    }

    public void GenerationTesting()
    {
        SceneManager.LoadScene("Generation Testing");
    }

    public void QuitGame()
    {
        Application.Quit();
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
