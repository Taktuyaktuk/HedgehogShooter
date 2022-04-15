using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameComplete : MonoBehaviour
{
    public static bool GamePaused;
    public GameObject _gameCompleteMenuUI;
    private float _normalTime = 1f;
    private float _stoppedTime = 0f;
    public TextMeshProUGUI GameOverText;

    public float TimePlayed;

    private void Awake()
    {
        _gameCompleteMenuUI = GameObject.Find("GameComplete");
        GamePaused = false;
        //_gameCompleteMenuUI.SetActive(false);
    }

    public void GameCompleted()
    {
        Time.timeScale = _stoppedTime;
        GamePaused = true;
        TimePlayed = TimerManager.myTimer;
        PlayerPrefs.SetFloat("LastTimePlayed", TimePlayed);
        TopScores(TimePlayed);
        GameOverText.text = ("Congratulation! You Complete all levels on this difficulty, your time is " + TimePlayed);

    }
    public void TopScores(float score)
    {
        float Score = score;

        float Score1 = PlayerPrefs.GetFloat("BestScore");
        float Score2 = PlayerPrefs.GetFloat("SecondScore");
        float Score3 = PlayerPrefs.GetFloat("ThirdScore");


        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            if (Score < Score1)
            {
                PlayerPrefs.SetFloat("BestScore", Score);
            }
        }
        if (SceneManager.GetActiveScene().buildIndex == 8)
        {
            if (Score < Score2)
            {
                PlayerPrefs.SetFloat("SecondScore", Score);
            }
        }
        if (SceneManager.GetActiveScene().buildIndex == 16)
        {
            if (Score < Score3)
            {
                PlayerPrefs.SetFloat("ThirdScore", Score);
            }
        }
    }

    public void Menu()
    {
        Time.timeScale = _normalTime;
        TimerManager.myTimer = 0;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Time.timeScale = _normalTime;
        TimerManager.myTimer = 0;
        Application.Quit();
    }

}
