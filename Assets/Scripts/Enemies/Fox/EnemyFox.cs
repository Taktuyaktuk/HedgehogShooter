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
    public bool DodgeActive;

    private Vector3 lastPosition;
    private Vector3 endPosition;
    


   

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        DodgeActive = false;
    }

    private void Update()
    {
        Move();
        Die();
        if (DodgeActive == true)
        {
            lastPosition = DodgeRightPoint.position;
            endPosition = DodgeEndPoint.position;
        }
        //Invoke("DodgeActivator", 11);
      
    }
   

    public void DodgeActivator()
    {
        DodgeActive = true;
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

        
       

        if (dist <= 4.5f && dist >= 1.5f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
            Debug.Log("ok_");
        }

        

        else if (dist > 4.5f)
        {
            int random = Random.Range(0, 100);

            if (random > 10)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
                Debug.Log("wysokiRandom");
                DodgeActive = true;
            }

            else 
               
            {
              DodgeActive = false;
                transform.Translate(Vector3.right * (Speed) * Time.deltaTime);

                //transform.position = Vector3.MoveTowards(RandomDirection(), RandomPostion(), Speed * Time.deltaTime);
                //Debug.Log("doszedl do PKT1");
                //if((Vector3.Distance(transform.position, endPosition) <= 1.5f))
                //{
                //    Debug.Log("doszedl do PKT2");
                //    transform.position = Vector3.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
                //    DodgeActive = false;
                //}
                //else
                //{
                //    transform.position = Vector3.MoveTowards(RandomDirection(), RandomPostion(), Speed * Time.deltaTime);
                //}
            }
                    


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
        }


    }

    public override void Respawn()
    {
        
    }

    public static Vector3 RandomDirection()
    {
        return new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
    private Vector3 RandomPostion()
    {
        return transform.position + RandomDirection() * Random.Range(5f, 5f);
    }
}
