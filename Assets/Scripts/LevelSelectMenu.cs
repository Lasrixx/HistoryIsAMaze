using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectMenu : MonoBehaviour
{


    public Image level01Tick;
    public Image level02Tick;
    public Image level03Tick;
    public Image level04Tick;
    public Image level05Tick;
    public Image level06Tick;
    public Image level07Tick;
    public Image level08Tick;

    public Text level01Score;
    public Text level02Score;
    public Text level03Score;
    public Text level04Score;
    public Text level05Score;
    public Text level06Score;
    public Text level07Score;
    public Text level08Score;

    void Start()
    {
        
        if ((PlayerPrefs.GetInt("Level01")) == 1)
        {
            level01Tick.enabled = true;
            level01Score.text = (PlayerPrefs.GetInt("Level01Score")).ToString();
        }
        else
        {
            level01Tick.enabled = false;
        }
        if ((PlayerPrefs.GetInt("Level02")) == 1)
        {
            level02Tick.enabled = true;
            level02Score.text = (PlayerPrefs.GetInt("Level02Score")).ToString();
        }
        else
        {
            level02Tick.enabled = false;
        }
        if ((PlayerPrefs.GetInt("Level03")) == 1)
        {
            level03Tick.enabled = true;
            level03Score.text = (PlayerPrefs.GetInt("Level03Score")).ToString();
        }
        else
        {
            level03Tick.enabled = false;
        }
        if ((PlayerPrefs.GetInt("Level04")) == 1)
        {
            level04Tick.enabled = true;
            level04Score.text = (PlayerPrefs.GetInt("Level04Score")).ToString();
        }
        else
        {
            level04Tick.enabled = false;
        }
        if ((PlayerPrefs.GetInt("Level05")) == 1)
        {
            level05Tick.enabled = true;
            level05Score.text = (PlayerPrefs.GetInt("Level05Score")).ToString();
        }
        else
        {
            level05Tick.enabled = false;
        }
        if ((PlayerPrefs.GetInt("Level06")) == 1)
        {
            level06Tick.enabled = true;
            level06Score.text = (PlayerPrefs.GetInt("Level06Score")).ToString();
        }
        else
        {
            level06Tick.enabled = false;
        }
        if ((PlayerPrefs.GetInt("Level07")) == 1)
        {
            level07Tick.enabled = true;
            level07Score.text = (PlayerPrefs.GetInt("Level07Score")).ToString();
        }
        else
        {
            level07Tick.enabled = false;
        }
        if ((PlayerPrefs.GetInt("Level08")) == 1)
        {
            level08Tick.enabled = true;
            level08Score.text = (PlayerPrefs.GetInt("Level08Score")).ToString();
        }
        else
        {
            level08Tick.enabled = false;
        }
    }

    public void LoadLevel01()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadLevel02()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadLevel03()
    {
        SceneManager.LoadScene(3);
    }
    public void LoadLevel04()
    {
        SceneManager.LoadScene(4);
    }
    public void LoadLevel05()
    {
        SceneManager.LoadScene(5);
    }
    public void LoadLevel06()
    {
        SceneManager.LoadScene(6);
    }
    public void LoadLevel07()
    {
        SceneManager.LoadScene(7);
    }
    public void LoadLevel08()
    {
        SceneManager.LoadScene(8);
    }
}
