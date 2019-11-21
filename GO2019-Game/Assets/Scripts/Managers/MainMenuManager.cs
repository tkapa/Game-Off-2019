﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject menuUI;

    [SerializeField]
    private GameObject optionsUI;

    [SerializeField]
    private GameObject creditsUI;

    [SerializeField]
    Button[] mmButtons;

    [Header("Options")]
    public Slider soundSlider;
    public Toggle invertYToggle;
    public Slider sensitivitySlider;

    public void Start() 
    {
        GameManager.gameManagerInstance.LoadGameData();
        soundSlider.value = GameManager.soundFloat;
        sensitivitySlider.value = GameManager.mouseSensitivity;
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

    public void OptionsMenu(){
        menuUI.SetActive(!menuUI.activeSelf);
        optionsUI.SetActive(!optionsUI.activeSelf);
    }

    public void SaveOptions(){
        SaveLoadManager.SaveGameData();
    }

    public void QuitGame()
    {
        SaveLoadManager.SaveGameData();
        
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
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

    public void CreditsMenu()
    {
        menuUI.SetActive(!menuUI.activeSelf);
        creditsUI.SetActive(!creditsUI.activeSelf);
    }
}
