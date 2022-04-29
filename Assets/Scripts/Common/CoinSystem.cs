using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSystem : MonoBehaviour
{
    private int _enemyCount;
    [SerializeField]
    private int _power;
    private Transform _coinTarget;
    private Rigidbody _rb;
    private bool _coinAdded;
    [SerializeField]
    private AudioSource _cashInSound;

    private void Awake()
    {
        OnAwake();
    }
    private void Start()
    {
        _enemyCount = GameObject.Find("---------Enemies---------").GetComponentsInChildren<Transform>().Length;
    }

    private void Update()
    {
        AddingCoins();
    }
    public void OnAwake()
    {
        if (_coinTarget == null)
        {
            _coinTarget = GameObject.Find("CoinTarget").GetComponent<Transform>();
        }

        _rb = this.GetComponent<Rigidbody>();
        _coinAdded = false;
    }

    public void AddingCoins()
    {
        _enemyCount = GameObject.Find("---------Enemies---------").GetComponentsInChildren<Transform>().Length;

        if (_enemyCount <= 1 && _coinAdded == false)
        {
            _coinAdded = true;
            int coins = PlayerPrefs.GetInt("Coins");
            coins += 1;
            var target = _coinTarget.position - this.transform.position;
            _rb.AddForce(target * _power);
            _cashInSound.Play();
            PlayerPrefs.SetInt("Coins", coins);
        }

        if (_coinAdded == true)
        {
            Destroy(gameObject, 0.5f);
        }
    }
}
