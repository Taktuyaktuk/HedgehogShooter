using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class SurvivalGameOverMenu : MonoBehaviour
{
    public static bool GamePaused;
    public GameObject _gameOverMenuUI;
    private float _normalTime = 1f;
    private float _stoppedTime = 0f;
    public TextMeshProUGUI GameOverText;
    private WaveSpawner _waveSpawner;

    public float TimePlayed;
    public int WaveReached;

    private void Awake()
    {
        _gameOverMenuUI = GameObject.Find("GameOverMenuUI");
        GamePaused = false;
        _gameOverMenuUI.SetActive(false);
        _waveSpawner = GameObject.Find("SpawnManager").GetComponent<WaveSpawner>();
    }

    public void Restart()
    {
        //_gameOverMenuUI.SetActive(false);
        //Time.timeScale = _normalTime;
        //GamePaused = false;
    }
    public void GameOver()
    {
        _gameOverMenuUI.SetActive(true);
        Time.timeScale = _stoppedTime;
        GamePaused = true;
        TimePlayed = TimerManager.myTimer;
        WaveReached = _waveSpawner.WaveNumber;
        //PlayerPrefs.SetFloat("LastWaveTime", TimePlayed);
        PlayerPrefs.SetInt("LastWave", WaveReached);
        GameOverText.text = ("You reached wave: " + WaveReached);
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

    public void TopWave(int Wave)
    {
        float Score = Wave;

        float Score1 = PlayerPrefs.GetFloat("LastWave");
      


        if (Score > Score1)
        {
            PlayerPrefs.SetFloat("LastWave", Score);
        }
    }
}
