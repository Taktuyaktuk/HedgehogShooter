using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float ProjectileSpeed = 100;
    public float DamageDone;
    public Vector3 Target;
    public GameObject Player;
    Rigidbody rb;
    NearestEnemyBehaviour Near;
    private bool _couritineActive = false;
    private bool _haveVelocity;
    public GameObject PlayerPosition;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
        PlayerPosition = GameObject.Find("Player");
    }
    private void Start()
    {
        Physics.IgnoreLayerCollision(6, 7);
        Player = GameObject.Find("Player");
        Shooting();
        
    }
    private void Update()
    {
        if(_haveVelocity == false)
        {
            _haveVelocity = true;
            Shooting();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyFox>().GetDamage(DamageDone);
        }
        if ( collision.transform.tag == "RangeEnemy1")
        {
            collision.gameObject.GetComponent<EnemyRange1>().GetDamage(DamageDone);
        }
        if (collision.transform.tag == "RangeEnemy2")
        {
            collision.gameObject.GetComponent<EnemyRange2>().GetDamage(DamageDone);
        }
        this.gameObject.transform.position = PlayerPosition.transform.position;
        _haveVelocity = false;
        this.gameObject.SetActive(false);
        rb.velocity = Vector3.zero;
    }

    private void Shooting()
    {
        Near = Player.GetComponent<NearestEnemyBehaviour>();
        try
        {
            Target = (Near.NearestEnemy.transform.position - transform.position).normalized;
        }
        catch
        {

        }
        DamageDone = Player.GetComponent<PlayerStats>().AttackPower;

        rb.AddForce(Target * ProjectileSpeed);
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
            this.gameObject.transform.position = PlayerPosition.transform.position;
            this.gameObject.SetActive(false);
            rb.velocity = Vector3.zero;
            _couritineActive = false;
            StopAllCoroutines();
        }
    }
}
