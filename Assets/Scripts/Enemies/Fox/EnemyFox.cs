using Assets.Scripts.Common;
using System.Collections;
using UnityEngine;
public enum state
{
    start,
    leftAchiving,
    rightAchiving,
    endAchived
}

public class EnemyFox : EnemyAbstract
{
    public override float Cooldown { get; set; }
    public override float HP { get; set; } = 100f;
    public override float Damage { get; set; } = 10f;
    [SerializeField]
    public override float Speed { get; set; } = 1f;

    private Transform target;

    public Transform DodgeRightPoint;
    public Transform DodgeLeftPoint;
    public Transform DodgeEndPoint;
    public bool DodgeActive;

    private Vector3 lastPosition;
    private Vector3 endPosition;
    
    private state _moveState;

    Vector3 leftPoint;
    Vector3 rightPoint;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag(Tags.Player.ToString()).GetComponent<Transform>();
        //DodgeActive = false;
        //_moveState = state.leftAchiving;

        //leftPoint = new Vector3(transform.position.x, 0, transform.position.z) + Vector3.left + Vector3.forward;
        //rightPoint = new Vector3(transform.position.x, 0, transform.position.z) + Vector3.right + Vector3.forward;
        
        Move();
    }

    private void Update()
    {
        //Die();
        if (DodgeActive == true)
        {
            lastPosition = DodgeRightPoint.position;
            endPosition = DodgeEndPoint.position;
        }
        //Invoke("DodgeActivator", 11);
        //Move();
        
    }

    //public void DodgeActivator()
    //{
    //    DodgeActive = true;
    //}

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

    public IEnumerator MoveCoroutine()
    {
        //poruszaj sie 

        //transform.Translate(Vector3.forward * Time.deltaTime * Speed);
        
            transform.position = Vector3.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
            yield return new WaitForSeconds(3f);
            StopCoroutine(MoveCoroutine());
            StartCoroutine(Stop());
        
        //zatrzymaj sie na 0.3f
    }
    public IEnumerator Stop()
    {
        
            print("stop1");
            yield return new WaitForSeconds(1f);
            print("stop2");
            StopCoroutine(Stop());
            StartCoroutine(MoveCoroutine());
        
    }
    public override void Move()
    {
        StartCoroutine(MoveCoroutine());
        print("dziala");
        //przeciwnika rusza sie w kierunku gracza,
        //transform.position = Vector3.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
        //po 1sek zatrzymuje sie na 0.3sek w miejscu
        //rusza sie dalej.


        //poruszanie sie i zatrzymanie bedzie zrobione na IEnumarotor Courine




        //if (_moveState == state.leftAchiving)
        //{
        //    transform.Translate(leftPoint * Time.deltaTime * Speed);
            
        //    if(Vector3.Distance(transform.position, leftPoint) < 0.2f)
        //    {
        //        rightPoint = transform.position + transform.TransformPoint(new Vector3(2, 0, 1.5f));
        //        _moveState = state.rightAchiving;
        //    }
        //}
        //else
        //{
        //    transform.Translate(rightPoint * Time.deltaTime * Speed);

        //    if (Vector3.Distance(transform.position, rightPoint) < 0.2f)
        //    {
        //        leftPoint = transform.position + transform.TransformPoint(new Vector3(-2, 0, 1.5f));
        //        _moveState = state.leftAchiving;
        //    }
        //}

        //return;
        //okresl punkt startu
        //okresl punkt konca
        //okresl wartosc w strone gracza + 0.5
        //okresl lewy point (-1,0,0)
        //okresl wartosc w strone gracza + 0.5
        //okresl prawy point (1,0,0)



        //transform.Translate(Vector3.forward * Time.deltaTime * Speed);
        
        //var rangeXDiagonal = .9f;

        //if (transform.position.x < rangeXDiagonal)
        //{
        //    transform.Translate(Vector3.left * 8 * Time.deltaTime * Speed);
        //}
        //if (transform.position.x > rangeXDiagonal)
        //{
        //    transform.Translate(Vector3.right * 8 * Time.deltaTime * Speed);
        //}

        //return;
        //float dist = Vector3.Distance(target.position, transform.position);

        //if (dist <= 4.5f && dist >= 1.5f)
        //{
        //    transform.position = Vector3.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
        //    Debug.Log("ok_");
        //}
        //else if (dist > 4.5f)
        //{
        //    int random = Random.Range(0, 100);

        //    if (random > 10)
        //    {
        //        transform.position = Vector3.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
        //        Debug.Log("wysokiRandom");
        //        DodgeActive = true;
        //    }
        //    else

        //    {
        //        DodgeActive = false;
        //        transform.Translate(Vector3.right * (Speed) * Time.deltaTime);

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

    public static Vector3 RandomDirection()
    {
        return new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }

    private Vector3 RandomPostion()
    {
        return transform.position + RandomDirection() * Random.Range(5f, 5f);
    }
}