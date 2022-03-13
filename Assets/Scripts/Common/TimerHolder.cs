using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerHolder : MonoBehaviour
{
    public float timer = 0;


    public void Update()
    {
        TimerManager.myTimer += Time.deltaTime;
        Debug.Log(TimerManager.myTimer);
    }
}
