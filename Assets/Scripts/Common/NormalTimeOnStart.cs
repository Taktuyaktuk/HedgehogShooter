using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalTimeOnStart : MonoBehaviour
{
    private float _normalTime = 1f;
    private void Start()
    {
        Time.timeScale = _normalTime;
    }
}
