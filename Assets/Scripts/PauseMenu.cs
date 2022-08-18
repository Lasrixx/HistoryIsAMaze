using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;
    public GameObject pauseMenuUI;
    public LevelLoader levelLoader;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isGamePaused)       
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }    
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }
    public void RestartLevel()
    {
        Time.timeScale = 1f;
        levelLoader.ReloadLevel();
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        levelLoader.LoadMainMenu();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
