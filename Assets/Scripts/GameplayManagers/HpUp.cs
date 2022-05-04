using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpUp : MonoBehaviour
{

    private PlayerStats _playerStats;
    public float HpHealAmount;

    private void Awake()
    {
        if(_playerStats == null)
        {
            _playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
        }
        if(HpHealAmount == 0)
        {
            HpHealAmount = 20;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(_playerStats.HP <= (_playerStats.MaxHP - HpHealAmount))
            {
                _playerStats.HP += HpHealAmount;
                _playerStats.GetHeal();
            }
            else if(_playerStats.HP > (_playerStats.MaxHP - HpHealAmount))
            {
                _playerStats.HP = _playerStats.MaxHP;
                _playerStats.GetHeal();
            }
            Destroy(gameObject);
        }
    }
}
