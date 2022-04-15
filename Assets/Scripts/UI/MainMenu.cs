using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private float _normalGameSpeed = 1f;
    public void PlayGameEasy()
    {
        Time.timeScale = _normalGameSpeed;
        TimerManager.myTimer = 0;
        PlayerPrefs.SetFloat("ActualHP", 100f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayGameMedium()
    {
        Time.timeScale = _normalGameSpeed;
        TimerManager.myTimer = 0;
        PlayerPrefs.SetFloat("ActualHP", 100f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void PlayGameHard()
    {
        Time.timeScale = _normalGameSpeed;
        TimerManager.myTimer = 0;
        PlayerPrefs.SetFloat("ActualHP", 100f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Survive()
    {
        Time.timeScale = _normalGameSpeed;
        TimerManager.myTimer = 0;
        PlayerPrefs.SetFloat("ActualHP", 100f);
        SceneManager.LoadScene("Survive");
    }


    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResetTopScores()
    {
        PlayerPrefs.SetFloat("BestScore", Mathf.Infinity);
        PlayerPrefs.SetFloat("SecondScore", Mathf.Infinity);
        PlayerPrefs.SetFloat("ThirdScore", Mathf.Infinity);
    }
}
