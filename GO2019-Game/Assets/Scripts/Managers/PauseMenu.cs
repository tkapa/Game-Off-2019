using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;

    public GameObject pauseUI;
    public GameObject gameUI;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(isPaused){
                Resume();
            } else{
                Pause();
            }
        }
    }

    public void Resume(){
        pauseUI.SetActive(false);
        gameUI.SetActive(true);
        SaveLoadManager.SaveGameData();
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false;       
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause(){
        pauseUI.SetActive(true);
        gameUI.SetActive(false);
        SaveLoadManager.SaveGameData();
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void LoadMenu(){
        Time.timeScale = 1f;
        SaveLoadManager.SaveGameData();
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame(){
        Time.timeScale = 1f;
        Debug.Log("Quitting Game");
        SaveLoadManager.SaveGameData();
        
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("Generation Testing");
    }
}
