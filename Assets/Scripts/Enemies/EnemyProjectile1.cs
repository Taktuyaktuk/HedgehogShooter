using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile1 : MonoBehaviour
{
    public float ProjectileSpeed = 1;
    public Vector3 TargetPlayer;
    public GameObject Player;
    public GameObject RangeEnemy1;
    Rigidbody rigidbody;
    public PlayerStats playerStats;
    private float _enemyDamage;

    private void Awake()
    {
        rigidbody = this.GetComponent<Rigidbody>();   
        
    }
    private void Start()
    {
        
        Physics.IgnoreLayerCollision(9, 8);
        Physics.IgnoreLayerCollision(7, 9);
        Physics.IgnoreLayerCollision(9, 9);
        Physics.IgnoreLayerCollision(9, 10);

        if (Player == null)
        {
           Player = GameObject.Find("Player"); 
        }
        if(RangeEnemy1 == null)
        {
            RangeEnemy1 = GameObject.FindGameObjectWithTag("RangeEnemy1");
        }
        if(playerStats == null)
        {
            playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
        }

        _enemyDamage = RangeEnemy1.GetComponent<EnemyRange1>().Damage;
        TargetPlayer = (Player.transform.position - this.transform.position).normalized;
        rigidbody.AddForce(TargetPlayer * ProjectileSpeed);
        Destroy(this.gameObject, 4f);
    }

    private void Update()
    {
        if (RangeEnemy1 == null)
        {
            RangeEnemy1 = GameObject.Find("Range enemy1");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerStats.GetDamage (_enemyDamage);
            Destroy(this.gameObject);
        }
        Destroy(this.gameObject);
        
    }
}
