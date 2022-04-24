using Assets.Scripts.Common;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFox : EnemyAbstract
{
    public override float Cooldown { get; set; }
    public override float HP { get; set; }
    public override float Damage { get; set; } = 10f;
    public override float Speed { get; set; } = 2f;

    public float MaxHP = 100;

    private Transform _targetPlayer;

    public bool DodgeActive;
    public float DmgGet;
    public float DmgSet = 10;
    public bool HitByPlayer;
    public bool InAttackRange;
    public bool DealedDamageToPlayer;
    public PlayerStats playerStats;

    private NavMeshAgent agent;
    public HealthBar EnemyHealthBar;
    public EnemyLoot EnemyLootManager;

    [SerializeField]
    private GameObject _psHitEnemy;


    private void Awake()
    {
        SafetyForNulls();
        SafetyOnAwake();
    }

    private void Update()
    {
        InAtackRange();
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
            Vector3 coinPosition = new Vector3(0, 0, -0.5f);
            EnemyLootManager.CoinLootGenerator(transform.position + coinPosition);
            Destroy(gameObject);
        }
    }

    public override void GetDamage(float damage)
    {
        HP -= damage;
        EnemyHealthBar.SetHealth(HP);
        Instantiate(_psHitEnemy, transform.position, Quaternion.identity);
        StartCoroutine(StopWhenGetDmg());
    }

    public override void Idle()
    {
    }

   
    public override void Move()
    {
        float minDist = 1.5f;
        float maxDist = 4.5f;
        float dist = Vector3.Distance(_targetPlayer.position, transform.position);

        if(dist >minDist && dist<maxDist && HitByPlayer == false)
        {
            agent.SetDestination(_targetPlayer.position);
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
                agent.SetDestination(_targetPlayer.position);
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
            playerStats.GetDamage(DmgSet);
            yield return new WaitForSeconds(delayedTime);
            DealedDamageToPlayer = false;
        } 
    }

    public void SafetyForNulls()
    {
        if (playerStats == null)
        {
            playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
        }

        if (EnemyLootManager == null)
        {
            EnemyLootManager = GameObject.Find("LootManager").GetComponent<EnemyLoot>();
        }

        if (_psHitEnemy == null)
        {
            _psHitEnemy = GameObject.Find("PS_HitEnemy");
        }
        _targetPlayer = GameObject.FindGameObjectWithTag(Tags.Player.ToString()).GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
    }
    public void SafetyOnAwake()
    {
        HP = MaxHP;
        EnemyHealthBar.SetMaxHealth(HP);
        HitByPlayer = false;
        InAttackRange = false;
        DealedDamageToPlayer = false;
        StartCoroutine(MoveCoroutine());
        agent.speed = Speed;
    }
    public void InAtackRange()
    {
        if (InAttackRange)
        {
            StartCoroutine(DealDamage());
        }
        else
        {
            StopCoroutine(DealDamage());
        }
    }
}