using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    GameManager gameManager;

    [Header("Options")]
    public Slider soundSlider;
    public Toggle invertYToggle;

    public void Start() 
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        soundSlider.value = gameManager.soundFloat;
        invertYToggle.isOn = gameManager.invertedY;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Testing Scene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SoundController()
    {        
        gameManager.soundFloat = soundSlider.value;
        AudioListener.volume = gameManager.soundFloat;
        Debug.Log(AudioListener.volume);
    }

    public void ToggleInvertedY(){
        gameManager.invertedY = invertYToggle.isOn;
    }
}
