using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesPowerUp : MonoBehaviour
{
    public WaveRecordChecker WaveChecker;
    private int _currentBonus;
    [SerializeField]
    private GameObject _enemies;

    private void Awake()
    {
        OnAwake();
    }

    private void Update()
    {
        EnemyPowerUp();
    }

    private void OnAwake()
    {
        if (WaveChecker == null)
        {
            WaveChecker = GameObject.Find("WaveRecordChecker").GetComponent<WaveRecordChecker>();
        }
        if (_enemies == null)
        {
            _enemies = GameObject.Find("---------Enemies---------");
        }
    }

    private void EnemyPowerUp()
    {
        if (WaveChecker._currentWave != _currentBonus)
        {
            _currentBonus = WaveChecker._currentWave;
            PlayerPrefs.SetFloat("EnemiesPowerUp", _currentBonus);
        }
    }

}
