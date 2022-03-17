using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private float _normalGameSpeed = 1f;
    public void PlayGame()
    {
        Time.timeScale = _normalGameSpeed;
        TimerManager.myTimer = 0;
        PlayerPrefs.SetFloat("ActualHP", 100f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
