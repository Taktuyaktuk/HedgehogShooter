using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange1ProjectileSpawner : MonoBehaviour
{
    Assets.Scripts.Common.ObjectPool.ObjectPooler objectPooler;
    public float RateOfFire { get; set; } = 1.0f;
    private bool _isCoroutineExecuting { get; set; } = false;


    void Start()
    {
        objectPooler = Assets.Scripts.Common.ObjectPool.ObjectPooler.Instance;
    }

    void Update()
    {
        ExecuteAfterTime();
    }
    IEnumerator ExecuteAfterTime()
    {
        if (_isCoroutineExecuting == true)
        {
            yield break;
        }

        _isCoroutineExecuting = true;
        objectPooler.SpawnFromPool("RangeEnemy1Projectile", transform.position, Quaternion.identity);
        yield return new WaitForSeconds(RateOfFire);
        _isCoroutineExecuting = false;
    }
}
