using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float MaxHP = 100;
    public float HP;
    public float AttackPower { get; set; } = 25;
    public int Level { get; set; }
    public HealthBar PlayerHealthBar;


    private void Start()
    {
        HP = MaxHP;
        PlayerHealthBar.SetMaxHealth(MaxHP);
    }

    private void LateUpdate()
    {
        if(HP<= 0)
        {
            Destroy(gameObject);
        }
    }

    public void GetDamage(float damage)
    {
        HP -= damage;
        PlayerHealthBar.SetHealth(HP);
    }

}
