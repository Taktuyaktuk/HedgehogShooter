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


    //public string Score1;
    //public string Score2;
    //public string Score3;

    public int HealthPointsBonus;
    public int AtackPowerBonus;
    public float SpeedBonus;

    private int _coins;

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
        Speed.text = SpeedBonus.ToString();

        //PlayerPrefs.SetInt("HPBonus", 0);
        //PlayerPrefs.SetInt("ATKBonus", 0);
        //PlayerPrefs.SetFloat("SpeedBonus", 0f);
    }

    public void HPUPButton()
    {
        if (_coins >= 10)
        {
            HealthPointsBonus += 10;
            PlayerPrefs.SetInt("HPBonus", HealthPointsBonus);
            _coins -= 10;
            PlayerPrefs.SetInt("Coins", _coins);
        }
        else
        {
            StartCoroutine(ChangeCoinsColor());
        }
    }
    public void AtackPowerButton()
    {
        if (_coins >= 10)
        {
            AtackPowerBonus += 1;
            PlayerPrefs.SetInt("ATKBonus", AtackPowerBonus);
            _coins -= 10;
            PlayerPrefs.SetInt("Coins", _coins);
        }
        else
        {
            StartCoroutine(ChangeCoinsColor());
        }
    }
    public void SpeedButton()
    {
        if (_coins >= 10)
        {
            SpeedBonus += 0.1f;
            PlayerPrefs.SetFloat("SpeedBonus", SpeedBonus);
            _coins -= 10;
            PlayerPrefs.SetInt("Coins", _coins);
        }
        else
        {
            StartCoroutine(ChangeCoinsColor());
        }
    }

    IEnumerator ChangeCoinsColor()
    {
        float time = 0.7f;
        Coins.fontSize = 40;
        Coins.faceColor = new Color32(245, 10, 13, 255);
        yield return new WaitForSeconds(time);
        Coins.fontSize = 30;
        Coins.faceColor = new Color32(245, 181, 13, 255);
        StopAllCoroutines();
    }
}
