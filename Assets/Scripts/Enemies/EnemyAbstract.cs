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

    public abstract void Attack();

    public abstract void GetDamage();

    public abstract void Die();

    public abstract void Respawn();

    public abstract void Dash();

    public abstract void Move();

    public abstract void Idle();

}
