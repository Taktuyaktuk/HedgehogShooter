using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{

    Assets.Scripts.Common.ObjectPool.ObjectPooler objectPooler;
    public float RateOfFire { get; set; } = 0.9f;
    public GameObject GhostJoystick;
    private List<Transform> _projectile;
    private bool _isCoroutineExecuting { get; set; } = false;
    public AudioSource Shoot;

    private void Awake()
    {
        if (GhostJoystick == null)
        {
            GhostJoystick = GameObject.Find("Ghost Joystic");
        }
       _projectile = this.transform.gameObject.GetComponent<NearestEnemyBehaviour>().EnemyList;
    }

    
    void Start()
    {
        objectPooler = Assets.Scripts.Common.ObjectPool.ObjectPooler.Instance;
    }

   
    void Update()
    {
        if (GhostJoystick.activeInHierarchy == true &&  _projectile.Count > 0)
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
        Shoot.Play();
        yield return new WaitForSeconds(RateOfFire);
        _isCoroutineExecuting = false;
    }
}
