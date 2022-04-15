using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitHolder : MonoBehaviour
{
    public GameObject Enemies;
    public GameObject Exit;
    private void Awake()
    {
        if(Enemies == null)
        {
            Enemies = GameObject.Find("---------Enemies---------");
        }
        if(Exit == null)
        {
            Exit = GameObject.Find("Exit");
        }
        Exit.SetActive(false);
    }
    private void Update()
    { 
        if(Enemies.transform.childCount < 1 )
        {
            Exit.SetActive(true);
        }
    }

   
}
