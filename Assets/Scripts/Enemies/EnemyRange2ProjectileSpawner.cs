using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange2ProjectileSpawner : MonoBehaviour
{
    Assets.Scripts.Common.ObjectPool.ObjectPooler objectPooler;
    public float RateOfFire { get; set; } = 2.0f;
    private bool _isCoroutineExecuting { get; set; } = false;
    public GameObject Enemy;
    public string PoolNameCenter;
    public string PoolNameLeft;
    public string PoolNameRight;

    private void Awake()
    {
        if (PoolNameCenter == "null")
        {
            PoolNameCenter = "RangeEnemy2ProjectileCenter";
        }
        if (PoolNameLeft == "null")
        {
            PoolNameLeft = "RangeEnemy2ProjectileLeft";
        }
        if (PoolNameRight == "null")
        {
            PoolNameRight = "RangeEnemy2ProjectileRight";
        }

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
        objectPooler.SpawnFromPool(PoolNameCenter, Enemy.transform.position, Quaternion.identity);
        objectPooler.SpawnFromPool(PoolNameLeft, Enemy.transform.position, Quaternion.identity);
        objectPooler.SpawnFromPool(PoolNameRight, Enemy.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(RateOfFire);
        _isCoroutineExecuting = false;
    }
}
