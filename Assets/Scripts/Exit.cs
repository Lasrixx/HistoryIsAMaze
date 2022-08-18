using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    private bool winGame = false;
    public LevelLoader levelLoader;
    public CountdownTimer timer;
    private bool stopFinalTimer;
    public PlayerBall player;
    private int diamondsAmountAtEnd;
    public FinalScore finalScore;
    private int score;

    void Start()
    {
        stopFinalTimer = false;
    }
    void Update()
    {
        if (winGame == true)
        {
            timer.ShowTimeLeftOnWin();

            finalScore.GetDiamondAmount(diamondsAmountAtEnd);
            finalScore.TotalScore();

            finalScore.CheckForEndOfGame();

            score = finalScore.finalScore;

            int sceneNumber = SceneManager.GetActiveScene().buildIndex;
            switch (sceneNumber)
            {
                case 1:
                    PlayerPrefs.SetInt("Level01", 1);                   //Using 1 to represent a completed level
                    PlayerPrefs.SetInt("Level01Score", score);
                    levelLoader.LoadNextLevel();
                    break;
                case 2:
                    PlayerPrefs.SetInt("Level02", 1);
                    PlayerPrefs.SetInt("Level02Score", score);
                    levelLoader.LoadNextLevel();
                    break;
                case 3:
                    PlayerPrefs.SetInt("Level03", 1);
                    PlayerPrefs.SetInt("Level03Score", score);
                    levelLoader.LoadNextLevel();
                    break;
                case 4:
                    PlayerPrefs.SetInt("Level04", 1);
                    PlayerPrefs.SetInt("Level04Score", score);
                    levelLoader.LoadNextLevel();
                    break;
                case 5:
                    PlayerPrefs.SetInt("Level05", 1);
                    PlayerPrefs.SetInt("Level05Score", score);
                    levelLoader.LoadNextLevel();
                    break;
                case 6:
                    PlayerPrefs.SetInt("Level06", 1);
                    PlayerPrefs.SetInt("Level06Score", score);
                    levelLoader.LoadNextLevel();
                    break;
                case 7:
                    PlayerPrefs.SetInt("Level07", 1);
                    PlayerPrefs.SetInt("Level07Score", score);
                    levelLoader.LoadNextLevel();
                    break;
                case 8:
                    PlayerPrefs.SetInt("Level08", 1);
                    PlayerPrefs.SetInt("Level08Score", score);
                    levelLoader.LoadMainMenu();
                    break;
            }
            

        }       
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            winGame = true;

            diamondsAmountAtEnd = player.diamondAmount;
        }
    }
}
