using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFox : EnemyAbstract
{
    public float Damage = 5f;
    public float HP = 100f;
    public float Cooldown = 1.0f;
    public float Speed = 2f;
    private Transform target;

    public Transform DodgeRightPoint;
    public Transform DodgeLeftPoint;
    public Transform DodgeEndPoint;


    private enum state
    {
        //follow,
        //zigZag,
        //atacking,
        dodgeStart,
        dodgeRight,
        dodgeLeft,
        dodgeEnd
    }

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
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
       if(HP <=0)
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
        float dist = Vector3.Distance(target.position, transform.position);
        Transform lastPosition;
        Transform lastPlayerPosition;

        if (dist <= 3.5f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
        }
        //else if ( dist > 3.5f)
        //{
            //int rnd = Random.Range(1, 3);
            //switch (state)
            //{
            //    default:
            //    case state.dodgeStart:
            //        lastPosition = DodgeRightPoint;
            //        transform.position = Vector3.MoveTowards(transform.position, lastPosition.position, Speed * Time.deltaTime);
            //        if(transform.position == lastPosition)
            //        {

            //        }
            //        break;
            //}
            

            //if (transform.position != DodgeRightPoint.position)
            //{
            //    transform.position = Vector3.MoveTowards(transform.position, DodgeRightPoint.position, Speed * Time.deltaTime);
            //}
            //else if (rnd == 2)
            //{
            //    transform.position = Vector3.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
            //}
            //else if (rnd == 3)
            //{
            //    target.di
            //}
        //}
        
        
    }

    public override void Respawn()
    {
        
    }
}
