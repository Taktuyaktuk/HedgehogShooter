using Assets.Scripts.Common;
using System.Collections;
using UnityEngine;

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
    public bool HitByPlayer;
   
    private void Awake()
    {
        HitByPlayer = false;
        target = GameObject.FindGameObjectWithTag(Tags.Player.ToString()).GetComponent<Transform>();
        StartCoroutine(MoveCoroutine());
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
        
        HP -= DmgGet;
       

    }

    public override void Idle()
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
        StartCoroutine(MoveCoroutine());
    }
    public override void Move()
    {
        float dist = Vector3.Distance(target.position, transform.position);

        if(dist >1.5 && dist<4.5 && HitByPlayer == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
        }
        else if( dist > 4.5 && HitByPlayer == false)
        {
            if (DodgeActive == true)
            {

            }
            else if( DodgeActive == false)
            {
                 transform.position = Vector3.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
            }
        }
        if(HitByPlayer == true)
        {

        }
    }

    public override void Respawn()
    {

    }
}