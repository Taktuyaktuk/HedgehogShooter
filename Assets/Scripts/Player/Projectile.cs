using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float ProjectileSpeed = 100;
    public Vector3 Target;

    Rigidbody rigidbody;
    public GameObject Player;


    
    NearestEnemyBehaviour Near;

    private void Awake()
    {

        rigidbody = this.GetComponent<Rigidbody>();

    }
    private void Start()
    {
        Physics.IgnoreLayerCollision(6, 7);
        Player = GameObject.Find("Player");
        Near = Player.GetComponent<NearestEnemyBehaviour>();
        Target = (Near.NearestEnemy.transform.position - transform.position).normalized;
        rigidbody.AddForce(Target * ProjectileSpeed);
        Destroy(this.gameObject, 4f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.transform.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyFox>().DmgGet = Player.GetComponent<PlayerStats>().AttackPower;
        }
        Destroy(gameObject);
    }
}
