using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile2Left : MonoBehaviour
{
    public float ProjectileSpeed = 1;
    public Vector3 TargetPlayer;
    public GameObject Player;
    public GameObject RangeEnemy2;
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
        if (RangeEnemy2 == null)
        {
            RangeEnemy2 = GameObject.FindGameObjectWithTag("RangeEnemy2");
        }
        if (playerStats == null)
        {
            playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
        }

        _enemyDamage = RangeEnemy2.GetComponent<EnemyRange2>().Damage;
        TargetPlayer = (Player.transform.position - this.transform.position).normalized;
        var direction = Quaternion.Euler(0, 30, 0) * TargetPlayer;
        rigidbody.AddForce((TargetPlayer + direction) * ProjectileSpeed);
        Destroy(this.gameObject, 4f);
    }

    private void Update()
    {
        if (RangeEnemy2 == null)
        {
            RangeEnemy2 = GameObject.Find("Range enemy2");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerStats.GetDamage(_enemyDamage);
            Destroy(this.gameObject);
        }
        Destroy(this.gameObject);

    }
}
