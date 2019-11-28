using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public PlayerMovement movement = null;

    public GameObject pauseUI;
    public GameObject gameUI;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !PlayerUIManager.isDead){
            if(isPaused){
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Resume(){
        pauseUI.SetActive(false);
        gameUI.SetActive(true);

        AudioListener.pause = false;

        SaveLoadManager.SaveGameData();
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false;       
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause(){
        pauseUI.SetActive(true);
        gameUI.SetActive(false);

        AudioListener.pause = true;

        SaveLoadManager.SaveGameData();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void LoadMenu(){
        Time.timeScale = 1f;
        AudioListener.pause = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SaveLoadManager.SaveGameData();
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame(){
        Time.timeScale = 1f;
        Debug.Log("Quitting Game");
        SaveLoadManager.SaveGameData();

        AudioListener.pause = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void RestartLevel()
    {
        AudioListener.pause = false;
        Cursor.lockState = CursorLockMode.Locked; 
        Time.timeScale = 1f;
        SceneManager.LoadScene("Generation Testing");
    }
}
