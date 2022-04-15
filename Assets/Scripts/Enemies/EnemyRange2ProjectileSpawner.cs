using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange2ProjectileSpawner : MonoBehaviour
{
    Assets.Scripts.Common.ObjectPool.ObjectPooler objectPooler;
    public float RateOfFire { get; set; } = 2.0f;
    private bool _isCoroutineExecuting { get; set; } = false;
    public GameObject Enemy;
    public string PoolName;

    private void Awake()
    {
        if (PoolName == "null")
        {
            PoolName = "RangeEnemy2ProjectileMulti";
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
        objectPooler.SpawnFromPool(PoolName, Enemy.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(RateOfFire);
        _isCoroutineExecuting = false;
    }
}
