using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerStats : MonoBehaviour
{
    public float MaxHP = 100;
    public float HP;
    public float AttackPower { get; set; } = 25;
    public int Level { get; set; }
    public HealthBarPlayer PlayerHealthBar;
    public GameObject GameOver;
    [SerializeField]
    private GameObject _psHit;
    [SerializeField]
    private GameObject _psHeal;
    [SerializeField]
    private AudioSource _healSound;
    [SerializeField]
    private AudioSource _getDamageSound;


    private void Awake()
    {
        HP = PlayerPrefs.GetFloat("ActualHP");
    }

    private void Start()
    {

        if (HP <1)
        {
            HP = MaxHP;
        }
        PlayerHealthBar.SetMaxHealth(MaxHP);
        PlayerHealthBar.SetHealth(HP);

        if(GameOver == null)
        {
            GameOver = GameObject.Find("GameOverMenu");
        }
    }

    private void LateUpdate()
    {
        if(HP<= 0)
        {
            GameOver.SetActive(true);
            GameOver.GetComponent<GameOverMenu>().GameOver();
        }
    }

    public void GetDamage(float damage)
    {
        HP -= damage;
        PlayerHealthBar.SetHealth(HP);
        PlayerPrefs.SetFloat("ActualHP", HP);
        GameObject CurrentPsEffect = Instantiate(_psHit, transform.position, Quaternion.identity);
        CurrentPsEffect.transform.parent = this.transform;
        _getDamageSound.Play();
    }
    public void GetHeal()
    {
        PlayerHealthBar.SetHealth(HP);
        PlayerPrefs.SetFloat("ActualHP", HP);
        GameObject CurrentPsEffect = Instantiate(_psHeal, transform.position, Quaternion.identity);
        CurrentPsEffect.transform.parent = this.transform;
        _healSound.Play();
    }

}
