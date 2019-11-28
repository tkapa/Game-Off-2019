using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject menuUI = null;

    [SerializeField]
    private GameObject optionsUI = null;

    [SerializeField]
    private GameObject creditsUI = null;

    [SerializeField]
    private GameObject controlsUI = null;

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

    public void PlayGame()
    {
        SceneManager.LoadScene("Testing Scene");
    }

    public void GenerationTesting()
    {
        SceneManager.LoadScene("Intro Scene");
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

    public void SoundController(float val)
    {        
        GameManager.soundFloat = val;
        AudioListener.volume = val;
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

    public void CreditsMenu()
    {
        menuUI.SetActive(!menuUI.activeSelf);
        creditsUI.SetActive(!creditsUI.activeSelf);
    }

    public void ControlsMenu()
    {
        menuUI.SetActive(!menuUI.activeSelf);
        controlsUI.SetActive(!controlsUI.activeSelf);
    }
}
