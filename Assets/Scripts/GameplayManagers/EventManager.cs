using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EventManager : MonoBehaviour
{

    public delegate void NearestObject();
    public static event NearestObject DistanceChecker;
    public GameObject GhostJoystick;

    private void Awake()
    {
        
        if (GhostJoystick == null)
        {
            GhostJoystick = GameObject.Find("Ghost Joystic");
        }
    }

    private void Update()
    {
        if (GhostJoystick.activeInHierarchy == true)
        {
            DistanceChecker();  
        }
    }
}
