using UnityEngine;

public abstract class EnemyAbstract : MonoBehaviour
{
    public abstract float Damage { get; set; }

    public abstract float HP { get; set; }

    public abstract float Cooldown { get; set; }

    public abstract float Speed { get; set; }

    public abstract void Attack();

    public abstract void GetDamage(float damage);

    public abstract void Die();

    public abstract void Respawn();

    public abstract void Dash();

    public abstract void Move();

    public abstract void Idle();
}