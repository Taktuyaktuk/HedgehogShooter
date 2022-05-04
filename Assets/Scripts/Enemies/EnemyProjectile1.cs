using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile1 : MonoBehaviour
{
    public float ProjectileSpeed = 1;
    public Vector3 TargetPlayer;
    public GameObject Player;
    public GameObject RangeEnemy1;
    Rigidbody rb;
    public PlayerStats playerStats;
    private float _enemyDamage;
    private bool _couritineActive;
    private bool _haveVelocity;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();

    }
    private void Start()
    {

        IgnoreCollisions();
        SafetyChecker();
        Shooting();
    }

    private void Update()
    {
        SafetyChecker();

        if(_haveVelocity == false)
        {
            _haveVelocity = true;
            Shooting();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerStats.GetDamage(_enemyDamage);
            this.gameObject.SetActive(false);
            rb.velocity = Vector3.zero;
            _haveVelocity = false;
        }
        this.gameObject.SetActive(false);
        rb.velocity = Vector3.zero;
        _haveVelocity = false;

    }

    private void IgnoreCollisions()
    {
        Physics.IgnoreLayerCollision(9, 8);
        Physics.IgnoreLayerCollision(7, 9);
        Physics.IgnoreLayerCollision(9, 9);
    }

    private void SafetyChecker()
    {
        if (Player == null)
        {
            Player = GameObject.Find("Player");
        }
        if (RangeEnemy1 == null)
        {
            RangeEnemy1 = GameObject.FindGameObjectWithTag("RangeEnemy1");
        }
        if (playerStats == null)
        {
            playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
        }
    }

    private void Shooting()
    {
        _enemyDamage = RangeEnemy1.GetComponent<EnemyRange1>().Damage;
        TargetPlayer = (Player.transform.position - this.transform.position).normalized;
        rb.AddForce(TargetPlayer * ProjectileSpeed);
        _haveVelocity = true;
        StartCoroutine(SetInactiveAfterTime());
    }

    IEnumerator SetInactiveAfterTime()
    {
        if (_couritineActive == false)
        {
            int time = 4;
            _couritineActive = true;
            yield return new WaitForSeconds(time);
            this.gameObject.SetActive(false);
            rb.velocity = Vector3.zero;
            _haveVelocity = false;
            _couritineActive = false;
            StopAllCoroutines();
        }
    }
}
