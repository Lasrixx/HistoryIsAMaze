using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    void Update()
    {
  
    }

    public void ReloadLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1)); 
    }

    public void LoadMainMenu()
    {
        StartCoroutine(LoadLevel(0));
    }

    IEnumerator LoadLevel(int levelIndex)       //This is a co-routine
    {
        //play animation
        yield return new WaitForSeconds(transitionTime);
        transition.SetTrigger("Start");
        //Wait for animation to stop
        yield return new WaitForSeconds(transitionTime);
        //Load next scene
        SceneManager.LoadScene(levelIndex);
    }
}
