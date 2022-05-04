using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    [SerializeField]
    private int _fireDamage;

    [SerializeField]
    private int _timeBetweenFireDmg;
    
    private bool _PlayerOnFire;
    PlayerStats playerStats;

    private void Awake()
    {
        OnAwake();
    }
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(DamageOverTime());
        }
    }
    private void OnAwake()
    {
        _PlayerOnFire = true;

        if (playerStats == null)
        {
            playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
        }

        if (_timeBetweenFireDmg == 0)
        {
            _timeBetweenFireDmg = 1;
        }
    }

    IEnumerator DamageOverTime()
    {
        if (_PlayerOnFire == true)
        {
            _PlayerOnFire = false;
            playerStats.GetDamage(_fireDamage);
            yield return new WaitForSeconds(1);
            _PlayerOnFire = true;
            StopAllCoroutines();
        }
    }
}
