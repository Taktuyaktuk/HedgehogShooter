using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameOverMenu : MonoBehaviour
{
    public static bool GamePaused;
    public GameObject _gameOverMenuUI;
    private float _normalTime = 1f;
    private float _stoppedTime = 0f;
    public TextMeshProUGUI GameOverText;
    [SerializeField]
    private string _sceneToRestart;

    public float TimePlayed;

    private void Awake()
    {
        _gameOverMenuUI = GameObject.Find("GameOverMenuUI");
        GamePaused = false;
        _gameOverMenuUI.SetActive(false);
    }

    public void Restart()
    {
        PlayerPrefs.SetFloat("EnemiesPowerUp", 0);
        _gameOverMenuUI.SetActive(false);
        Time.timeScale = _normalTime;
        GamePaused = false;
        SceneManager.LoadScene(_sceneToRestart);
    }
    public void GameOver()
    {
        PlayerPrefs.SetFloat("EnemiesPowerUp", 0);
        _gameOverMenuUI.SetActive(true);
        Time.timeScale = _stoppedTime;
        GamePaused = true;
        TimePlayed = TimerManager.myTimer;
        PlayerPrefs.SetFloat("LastTimePlayed", TimePlayed);
        GameOverText.text = ("You are Dead.");
    }
  

    public void Menu()
    {
        PlayerPrefs.SetFloat("EnemiesPowerUp", 0);
        Time.timeScale = _normalTime;
        TimerManager.myTimer = 0;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        PlayerPrefs.SetFloat("EnemiesPowerUp", 0);
        Time.timeScale = _normalTime;
        TimerManager.myTimer = 0;
        Application.Quit();
    }

    public void TopScores(float score)
    {
        float Score = score;

        float Score1 = PlayerPrefs.GetFloat("BestScore");
        float Score2 = PlayerPrefs.GetFloat("SecondScore");
        float Score3 = PlayerPrefs.GetFloat("ThirdScore");
        

        if (Score < Score1)
        {
            PlayerPrefs.SetFloat("BestScore", Score);
        }
        else if( Score < Score2 && Score > Score1)
        {
            PlayerPrefs.SetFloat("SecondScore", Score);
        }
        else if( Score < Score3 && Score > Score1 && Score > Score2)
        {
            PlayerPrefs.SetFloat("ThirdScore", Score);
        }
    }
}
