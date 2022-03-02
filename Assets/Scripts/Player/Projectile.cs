using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float ProjectileSpeed = 100;
    public Vector3 Target;
    public GameObject Player;
    Rigidbody rigidbody;
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
        try
        {
            Target = (Near.NearestEnemy.transform.position - transform.position).normalized;
        }
        catch
        {

        }
        rigidbody.AddForce(Target * ProjectileSpeed);
        Destroy(this.gameObject, 4f);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyFox>().HP -= Player.GetComponent<PlayerStats>().AttackPower;
        }
        Destroy(gameObject);
    }
}
