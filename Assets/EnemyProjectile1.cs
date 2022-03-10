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

    private void Awake()
    {
        
        Player = GameObject.Find("Player");
        rigidbody = this.GetComponent<Rigidbody>();
        
    }
    private void Start()
    {
        Physics.IgnoreLayerCollision(9, 8);
        Physics.IgnoreLayerCollision(7, 9);

        if (Player == null)
        {
           Player = GameObject.Find("Player"); 
        }
        if(RangeEnemy1 == null)
        {
            RangeEnemy1 = GameObject.Find("Range enemy1");
        }
        TargetPlayer = (Player.transform.position - this.transform.position).normalized;
        rigidbody.AddForce(TargetPlayer * ProjectileSpeed);
        Destroy(this.gameObject, 4f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.GetComponent<PlayerStats>().HP -= RangeEnemy1.GetComponent<EnemyRange1>().Damage;
            Destroy(this.gameObject);
        }
        Destroy(this.gameObject);
        
    }
}
