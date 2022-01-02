using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAbstract : MonoBehaviour
{
    [SerializeField]  
    protected float Damage  { get; set; }
    [SerializeField]
    protected   float  HP { get; set; }
    [SerializeField]
    protected float Cooldown { get; set; }
    [SerializeField]
    protected float Speed { get; set; }

    public virtual void Attack()
    {

    }

    public virtual void GetDamage()
    {

    }

    public virtual void Die()
    {

    }

    public virtual void Respawn()
    {

    }

    public virtual void Dash()
    {

    }

    public virtual void Move()
    {

    }

    public virtual void Idle()
    {

    }

}
