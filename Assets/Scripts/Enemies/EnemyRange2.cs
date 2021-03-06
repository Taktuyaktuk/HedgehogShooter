using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyRange2 : EnemyAbstract
{
    public override float Damage { get; set; } = 8;
    public override float HP { get; set; }
    public override float Cooldown { get; set; }
    public override float Speed { get; set; } = 1;
    public float MaxHP;

    private Transform _targetPlayer;
    [SerializeField]
    private NavMeshAgent agent;

    public bool DodgeActive;
    public float DmgGet;
    public bool HitByPlayer;
    public bool Attacking;
    public HealthBar EnemyHealthBar;
    public EnemyLoot EnemyLootManager;

    public bool ReachDestination;

    [SerializeField]
    private GameObject _psHitEnemy;

    private void Awake()
    {
        OnAwake();
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
            EnemyLootManager.LootGenerator(transform.position);
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
    }

    public override void Idle()
    {

    }

    public override void Move()
    {
        if (ReachDestination == false)
        {
            StartCoroutine(MoveCoroutine());
        }    
    }

    public IEnumerator MoveCoroutine()
    {
        ReachDestination = true;
        NavMeshHit hit;   
        Vector3 randompoint = transform.position + (Random.insideUnitSphere *2);
        NavMesh.SamplePosition(randompoint, out hit, 10, 1);
        agent.SetDestination(hit.position);

        yield return new WaitForSeconds(2f);
        ReachDestination = false;
        StopCoroutine(MoveCoroutine());
    }

    public override void Respawn()
    {

    }

    public void OnAwake()
    {
        int baseMaxHp = 120;
        int baseDamage = 8;

        MaxHP = baseMaxHp + PlayerPrefs.GetFloat("EnemiesPowerUp");
        Damage = baseDamage + PlayerPrefs.GetFloat("EnemiesPowerUp");

        HP = MaxHP;
        EnemyHealthBar.SetMaxHealth(HP);

        _targetPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = Speed;
        Attacking = false;
        ReachDestination = false;

        if (EnemyLootManager == null)
        {
            EnemyLootManager = GameObject.Find("LootManager").GetComponent<EnemyLoot>();
        }
    }
}