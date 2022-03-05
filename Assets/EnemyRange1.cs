using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyRange1 : EnemyAbstract
{
    public override float Damage { get; set; } = 10;
    public override float HP { get; set; } = 70;
    public override float Cooldown { get; set; }
    public override float Speed { get; set; } = 1;

    private Transform _targetPlayer;
    private NavMeshAgent agent;

    public bool DodgeActive;
    public float DmgGet;
    public float DmgSet = 10;
    public bool HitByPlayer;
    public bool Attacking;
    

    private void Awake()
    {
        _targetPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = Speed;
        Attacking = false;
    }

    private void Update()
    {
        Move();
    }

    public override void Attack()
    {
        
    }

    public override void Dash()
    {
        
    }

    public override void Die()
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }

    public override void GetDamage()
    {
       
    }

    public override void Idle()
    {
        
    }

    public override void Move()
    {

        float minDist = 4.5f;
        float maxDist = 8f;
        float dist = Vector3.Distance(_targetPlayer.position, transform.position);

        if (dist < maxDist)
        {
            agent.isStopped = false;
            agent.SetDestination((transform.position + ((transform.position - _targetPlayer.position) * 1f)));
        }
        else if (dist > maxDist)
        {
            agent.isStopped = true;
        }
        if (HitByPlayer == true)
        {
            agent.isStopped = true;
        }
        if (dist > maxDist)
        {
            Attack();
        }
        else if (dist > maxDist)
        {
            agent.isStopped = false;
        }
    }


    public override void Respawn()
    {
        
    }
}