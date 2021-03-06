using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStatsUI : MonoBehaviour
{
    public TextMeshProUGUI HealthPoints;
    public TextMeshProUGUI AtackPower;
    public TextMeshProUGUI Speed;
    public TextMeshProUGUI Coins;

    public int HealthPointsBonus;
    public int AtackPowerBonus;
    public float SpeedBonus;

    private int _coins;
    [SerializeField]
    private AudioSource _successCoinSound;
    [SerializeField]
    private AudioSource _failSound;



    private void Awake()
    {
        HealthPointsBonus = PlayerPrefs.GetInt("HPBonus");
        AtackPowerBonus = PlayerPrefs.GetInt("ATKBonus");
        SpeedBonus = PlayerPrefs.GetFloat("SpeedBonus");
        _coins = PlayerPrefs.GetInt("Coins");
    }

    public void Update()
    {
        HealthPointsBonus = PlayerPrefs.GetInt("HPBonus");
        AtackPowerBonus = PlayerPrefs.GetInt("ATKBonus");
        SpeedBonus = PlayerPrefs.GetFloat("SpeedBonus");
        _coins = PlayerPrefs.GetInt("Coins");
    }

    private void LateUpdate()
    {
        HealthPoints.text = HealthPointsBonus.ToString();
        AtackPower.text = AtackPowerBonus.ToString();
        Speed.text = SpeedBonus.ToString("0.#");
    }

    public void HPUPButton()
    {
        if (_coins >= 10)
        {
            _successCoinSound.Play();
            HealthPointsBonus += 10;
            PlayerPrefs.SetInt("HPBonus", HealthPointsBonus);
            _coins -= 10;
            PlayerPrefs.SetInt("Coins", _coins);
        }
        else
        {
            _failSound.Play();
            StartCoroutine(ChangeCoinsColor());
        }
    }
    public void AtackPowerButton()
    {
        if (_coins >= 10)
        {
            _successCoinSound.Play();
            AtackPowerBonus += 1;
            PlayerPrefs.SetInt("ATKBonus", AtackPowerBonus);
            _coins -= 10;
            PlayerPrefs.SetInt("Coins", _coins);
        }
        else
        {
            _failSound.Play();
            StartCoroutine(ChangeCoinsColor());
        }
    }
    public void SpeedButton()
    {
        if (_coins >= 10)
        {
            _successCoinSound.Play();
            SpeedBonus += 0.1f;
            PlayerPrefs.SetFloat("SpeedBonus", SpeedBonus);
            _coins -= 10;
            PlayerPrefs.SetInt("Coins", _coins);
        }
        else
        {
            _failSound.Play();
            StartCoroutine(ChangeCoinsColor());
        }
    }

    IEnumerator ChangeCoinsColor()
    {
        float time = 0.7f;
        float timescale = 1f;
        Time.timeScale = timescale;
        Coins.fontSize = 40;
        Coins.faceColor = new Color32(245, 10, 13, 255);
        yield return new WaitForSeconds(time);
        Coins.fontSize = 30;
        Coins.faceColor = new Color32(245, 181, 13, 255);
        StopAllCoroutines();
    }
}
