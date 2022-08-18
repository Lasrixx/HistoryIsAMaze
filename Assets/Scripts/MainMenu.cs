using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Loads next level in build settings 
    }
    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit(); 
    }
}
