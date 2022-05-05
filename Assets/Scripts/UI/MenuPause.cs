using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    public static bool GamePaused;
    private GameObject _menuPauseUI;
    private float _normalTime = 1f;
    private float _stoppedTime = 0f;

    private void Awake()
    {
        _menuPauseUI = GameObject.Find("MenuPauseUI");
        GamePaused = false;
        _menuPauseUI.SetActive(false);
    }

    public void Resume()
    {
        _menuPauseUI.SetActive(false);
        Time.timeScale = _normalTime;
        GamePaused = false;
    }

    public void Pause()
    {
        _menuPauseUI.SetActive(true);
        Time.timeScale = _stoppedTime;
        GamePaused = true;
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

}
