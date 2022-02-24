using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{

    Assets.Scripts.Common.ObjectPool.ObjectPooler objectPooler;
    public float RateOfFire { get; set; } = 1.0f;
    public GameObject GhostJoystick;
    private bool _isCoroutineExecuting { get; set; } = false;

    private void Awake()
    {
        if (GhostJoystick == null)
        {
            GhostJoystick = GameObject.Find("Ghost Joystic");
        }
    }

    
    void Start()
    {
        objectPooler = Assets.Scripts.Common.ObjectPool.ObjectPooler.Instance;
    }

   
    void Update()
    {
        if (GhostJoystick.activeInHierarchy == true)
        {
            StartCoroutine(ExecuteAfterTime());
        }
    }


    
    IEnumerator ExecuteAfterTime()
    {
        if(_isCoroutineExecuting == true)
        {
            yield break;
        }

        _isCoroutineExecuting = true;
        objectPooler.SpawnFromPool("PlayersProjectile", transform.position, Quaternion.identity);
        yield return new WaitForSeconds(RateOfFire);
        _isCoroutineExecuting = false;
    }
}
