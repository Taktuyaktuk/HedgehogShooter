using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private float _normalGameSpeed = 1f;
    public void PlayGameEasy()
    {
        PlayerPrefs.SetFloat("EnemiesPowerUp", 0);
        Time.timeScale = _normalGameSpeed;
        TimerManager.myTimer = 0;
        PlayerPrefs.SetFloat("ActualHP", 100f);
        SceneManager.LoadScene("Arena1Easy");
    }

    public void PlayGameMedium()
    {
        PlayerPrefs.SetFloat("EnemiesPowerUp", 0);
        Time.timeScale = _normalGameSpeed;
        TimerManager.myTimer = 0;
        PlayerPrefs.SetFloat("ActualHP", 100f);
        SceneManager.LoadScene("Arena1Medium");
    }
    public void PlayGameHard()
    {
        PlayerPrefs.SetFloat("EnemiesPowerUp", 0);
        Time.timeScale = _normalGameSpeed;
        TimerManager.myTimer = 0;
        PlayerPrefs.SetFloat("ActualHP", 100f);
        SceneManager.LoadScene("Arena1Hard");
    }

    public void Survive()
    {
        PlayerPrefs.SetFloat("EnemiesPowerUp", 0);
        int HpSurvive = (100 + PlayerPrefs.GetInt("HPBonus"));
        Time.timeScale = _normalGameSpeed;
        TimerManager.myTimer = 0;
        PlayerPrefs.SetFloat("ActualHP", HpSurvive);
        SceneManager.LoadScene("Survive");
    }


    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResetTopScores()
    {
        int reset = 0;
        PlayerPrefs.SetFloat("BestScore", Mathf.Infinity);
        PlayerPrefs.SetFloat("SecondScore", Mathf.Infinity);
        PlayerPrefs.SetFloat("ThirdScore", Mathf.Infinity);
        PlayerPrefs.SetInt("WaveRecord", reset);
    }
}
