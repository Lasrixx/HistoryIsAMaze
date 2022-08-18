using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{

    private float timeLeftSeconds;
    private float diamondsCollected;
    private float diamondMultiplier = 50f;
    public int finalScore;
    public Text finalScoreText;
    private bool endGame = false;

    void Update()
    {
        if (endGame == false)
        {
            finalScoreText.enabled = false;
        }
        else
        {
            finalScoreText.enabled = true;
        }
    }

    public void GetTimeLeft(float time)
    {
        timeLeftSeconds = time;
    }

    public void GetDiamondAmount(int diamonds)
    {
        diamondsCollected = diamonds;
    }

    public void TotalScore()
    {
        float score = timeLeftSeconds + (diamondsCollected * diamondMultiplier);
        finalScore = Mathf.RoundToInt(score);
        
        finalScoreText.text = ("SCORE: " + finalScore.ToString());
    }

    public void CheckForEndOfGame()
    {
        endGame = true;
    }
}
