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
    public float DmgSet;
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
        
        Move();
        
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
        
        HP -= DmgGet;
        StartCoroutine(StopWhenGetDmg());
       

    }

    public override void Idle()
    {
    }

   
    public override void Move()
    {
        float dist = Vector3.Distance(target.position, transform.position);

        if(dist >1.5 && dist<4.5 && HitByPlayer == false)
        {
            agent.SetDestination(target.position);
        }
        else if( dist > 4.5 && HitByPlayer == false)
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
        if(dist<1.5)
        {
            agent.isStopped = true;
            InAttackRange = true;
            Attack();
        }
        else if( dist>1.5 && DodgeActive==false )
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
        DodgeActive = false;
        HitByPlayer = false;
        yield return new WaitForSeconds(3f);
        DodgeActive = true;
        StopCoroutine(MoveCoroutine());
        StartCoroutine(Stop());
    }
    public IEnumerator Stop()
    {
        yield return new WaitForSeconds(0.5f);

        StopCoroutine(Stop());
        StartCoroutine(MoveCoroutine());
    }
    public IEnumerator StopWhenGetDmg()
    {
        StopCoroutine(Stop());
        HitByPlayer = true;
        yield return new WaitForSeconds(0.5f);
        HitByPlayer = false;
        StartCoroutine(MoveCoroutine());
        StopCoroutine(StopWhenGetDmg());
    }

    public IEnumerator DealDamage()
    {
        if (InAttackRange == true && DealedDamageToPlayer == false)
        {
            DmgSet = Damage;
            DealedDamageToPlayer = true;
            yield return new WaitForSeconds(0.5f);
            DealedDamageToPlayer = false;

        }
    }
}