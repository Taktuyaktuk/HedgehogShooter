using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float ProjectileSpeed = 100;
    public float DamageDone;
    public Vector3 Target;
    public GameObject Player;
    Rigidbody rigidbody;
    NearestEnemyBehaviour Near;
    private bool CouritineActive = false;
    public GameObject PlayerPosition;

    private void Awake()
    {
        rigidbody = this.GetComponent<Rigidbody>();
        PlayerPosition = GameObject.Find("Player");
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
        DamageDone = Player.GetComponent<PlayerStats>().AttackPower;

        rigidbody.AddForce(Target * ProjectileSpeed);
        StartCoroutine(SetInactiveAfterTime());

       
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
        this.gameObject.SetActive(false);
    }

    IEnumerator SetInactiveAfterTime()
    {
        if (CouritineActive)
        {
            int time = 4;
            CouritineActive = true;
            yield return new WaitForSeconds(time);
            this.gameObject.SetActive(false);
            this.gameObject.transform.position = PlayerPosition.transform.position;
            CouritineActive = false;
            StopAllCoroutines();
        }
    }
}
