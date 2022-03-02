using Assets.Scripts.Common;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFox : EnemyAbstract
{
    public override float Cooldown { get; set; }
    public override float HP { get; set; } = 100f;
    public override float Damage { get; set; } = 10f;
    [SerializeField]
    public override float Speed { get; set; } = 1f;

    private Transform target;

    public bool DodgeActive;
    public float DmgGet;
    public float DmgSet = 10;
    public bool HitByPlayer;
    public bool InAttackRange;
    public bool DealedDamageToPlayer;

    private NavMeshAgent agent;

   
    private void Awake()
    {
        HitByPlayer = false;
        InAttackRange = false;
        DealedDamageToPlayer = false;
        target = GameObject.FindGameObjectWithTag(Tags.Player.ToString()).GetComponent<Transform>();
        StartCoroutine(MoveCoroutine());
        agent = GetComponent<NavMeshAgent>();
        agent.speed = Speed;
    }

    private void Update()
    {
        if (InAttackRange)
        {
            StartCoroutine(DealDamage());
        }
        else
        {
            StopCoroutine(DealDamage());
        }
        Move();
        Die();  
    }

    
    public override void Attack()
    {
        StartCoroutine(DealDamage());
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
        //HP -= DmgGet;
        //StartCoroutine(StopWhenGetDmg());
        //Debug.Log("Pozosta³o HP " + HP) ;
    }
    
    public override void Idle()
    {
    }

   
    public override void Move()
    {
        float minDist = 1.5f;
        float maxDist = 4.5f;
        float dist = Vector3.Distance(target.position, transform.position);

        if(dist >minDist && dist<maxDist && HitByPlayer == false)
        {
            agent.SetDestination(target.position);
        }
        else if( dist > maxDist && HitByPlayer == false)
        {
            if (DodgeActive == true)
            {
                agent.isStopped = true;
            }
            else if( DodgeActive == false)
            {
                agent.isStopped = false;
                agent.SetDestination(target.position);
            }
        }
        if(HitByPlayer == true)
        {
            agent.isStopped = true;
        }
        if(dist<minDist)
        {
            agent.isStopped = true;
            InAttackRange = true;
            Attack();
        }
        else if( dist>minDist && DodgeActive==false )
        {
            agent.isStopped = false;
            InAttackRange = false;
        }
    }

    public override void Respawn()
    {

    }

    public IEnumerator MoveCoroutine()
    {
        float delayedTime = 3f;
        DodgeActive = false;
        HitByPlayer = false;
        yield return new WaitForSeconds(delayedTime);
        DodgeActive = true;
        StopCoroutine(MoveCoroutine());
        StartCoroutine(Stop());
    }
    public IEnumerator Stop()
    {
        float delayedTime = 0.5f;
        yield return new WaitForSeconds(delayedTime);

        StopCoroutine(Stop());
        StartCoroutine(MoveCoroutine());
    }
    public IEnumerator StopWhenGetDmg()
    {
        float delayedTime = 0.5f;
        StopCoroutine(Stop());
        HitByPlayer = true;
        yield return new WaitForSeconds(delayedTime);
        HitByPlayer = false;
        StartCoroutine(MoveCoroutine());
        StopCoroutine(StopWhenGetDmg());
    }

    public IEnumerator DealDamage()
    {
        float delayedTime = 0.5f;
        if (InAttackRange == true && DealedDamageToPlayer == false)
        {
            DmgSet = Damage;
            DealedDamageToPlayer = true;
            target.GetComponent<PlayerStats>().HP -= DmgSet;
            yield return new WaitForSeconds(delayedTime);
            DealedDamageToPlayer = false;
        } 
    }
}