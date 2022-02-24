using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{

    Assets.Scripts.Common.ObjectPool.ObjectPooler objectPooler;
    public float RateOfFire { get; set; } = 1.0f;
    public float NextSpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        objectPooler = Assets.Scripts.Common.ObjectPool.ObjectPooler.Instance;
        NextSpawnTime = Time.time + RateOfFire;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > NextSpawnTime)
        {
            objectPooler.SpawnFromPool("PlayersProjectile", transform.position, Quaternion.identity);
            NextSpawnTime += RateOfFire;
        }
    }

    private void FixedUpdate()
    {
        //Fire();
    }
    
    //IEnumerator Fire()
    //{
    //    Debug.Log("projectile Spawned")
    //        objectPooler.SpawnFromPool("PlayersProjectile", transform.position, Quaternion.identity);
    //    yield return new WaitForSeconds(RateOfFire);
       
    //}
}
