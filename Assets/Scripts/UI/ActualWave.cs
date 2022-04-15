using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ActualWave : MonoBehaviour
{
    public TextMeshProUGUI Wave;
    WaveSpawner SpawnManager;
    private void Awake()
    {
        if(SpawnManager == null)
        {
            SpawnManager = GameObject.Find("SpawnManager").GetComponent<WaveSpawner>();
        }
    }
   
    private void Update()
    {
        Wave.text = SpawnManager.WaveNumber.ToString();
    }

}
