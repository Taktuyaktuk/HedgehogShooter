using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyRange1 : EnemyAbstract
{
    public override float Damage { get; set; } = 10;
    public override float HP { get; set; }
    public override float Cooldown { get; set; }
    public override float Speed { get; set; } = 1;
    public float MaxHP = 70;

    private Transform _targetPlayer;
    private NavMeshAgent agent;

    public bool DodgeActive;
    public float DmgGet;
    public bool HitByPlayer;
    public bool Attacking;
    public HealthBar EnemyHealthBar;

    private void Awake()
    {
        HP = MaxHP;
        EnemyHealthBar.SetMaxHealth(HP);

        _targetPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = Speed;
        Attacking = false;
    }

    private void Update()
    {
        Move();
        Die();
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

    public override void GetDamage(float damage)
    {
        HP -= damage;
        EnemyHealthBar.SetHealth(HP);
    }

    public override void Idle()
    {
        
    }

    public override void Move()
    {
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
       
        else if (dist > maxDist)
        {
            agent.isStopped = false;
        }
    }


    public override void Respawn()
    {
        
    }
}