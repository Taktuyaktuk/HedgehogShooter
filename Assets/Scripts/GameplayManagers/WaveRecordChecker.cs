using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveRecordChecker : MonoBehaviour
{
    private WaveSpawner _wave;
    [SerializeField]
    public int _currentWave;

    private void Awake()
    {
        if(_wave == null)
        {
            _wave = GameObject.Find("SpawnManager").GetComponent<WaveSpawner>();
        }
        _currentWave = 0;
    }

    private void Update()
    {
        if(_currentWave < _wave.WaveNumber)
        {
            _currentWave = _wave.WaveNumber;
            if (_currentWave > PlayerPrefs.GetInt("WaveRecord"))
            {
                PlayerPrefs.SetInt("WaveRecord", _currentWave);
            }
        }
    }
}
