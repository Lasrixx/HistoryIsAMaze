using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public Text text;
    public Text finalTimeText;
    private string finalTime;
    public float startTime;
    private bool endGame = false;
    public LevelLoader levelLoader;
    public FinalScore finalScore;
    private float timeLeft;
    private float finalTimeInSeconds;

    private string timeText;

    void Start()
    {
        
    }
    void Update()
    {
        
        timeLeft = startTime - Time.timeSinceLevelLoad;
        int minutes = Mathf.FloorToInt(timeLeft / 60f);
        int seconds = Mathf.FloorToInt(timeLeft - minutes * 60f);

        timeText = string.Format("{0:0}:{1:00}", minutes, seconds);
        if (endGame == false)
        {
            text.text = timeText;
            finalTimeText.enabled = false;
            finalTime = timeText;
            finalTimeInSeconds = timeLeft;
        }
        if (timeLeft <= 0)
        {
            text.text = "0";
            finalTimeText.enabled = true;
            finalTimeText.text = "YOU RAN OUT OF TIME";
            levelLoader.ReloadLevel();
            endGame = true;
        }

    }

    public void ShowTimeLeftOnWin()     //As well as sending time left to the final score script
    {
        endGame = true;
        finalScore.GetTimeLeft(finalTimeInSeconds);   
    }
    //Replaced with showing score including diamonds


}
