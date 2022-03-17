using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerHolder : MonoBehaviour
{
    public float timer = 0;


    public void Update()
    {
        timer = TimerManager.myTimer += Time.deltaTime;
    }
}
