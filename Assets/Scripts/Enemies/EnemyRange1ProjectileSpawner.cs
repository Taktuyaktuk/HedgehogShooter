using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange1ProjectileSpawner : MonoBehaviour
{
    Assets.Scripts.Common.ObjectPool.ObjectPooler objectPooler;
    public float RateOfFire { get; set; } = 2.0f;
    private bool _isCoroutineExecuting { get; set; } = false;
    public GameObject Enemy;

    private void Awake()
    {
        
    }

    void Start()
    {
        objectPooler = Assets.Scripts.Common.ObjectPool.ObjectPooler.Instance;
    }

    void Update()
    {
        StartCoroutine(ExecuteAfterTime());
    }
    private IEnumerator ExecuteAfterTime()
    {
       
        if (_isCoroutineExecuting == true)
        {
            yield break;
        }

        _isCoroutineExecuting = true;
        objectPooler.SpawnFromPool("RangeEnemy1Projectile", Enemy.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(RateOfFire);
        _isCoroutineExecuting = false;
    }
}
