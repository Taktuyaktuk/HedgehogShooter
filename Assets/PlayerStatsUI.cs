using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStatsUI : MonoBehaviour
{
    public TextMeshProUGUI HealthPoints;
    public TextMeshProUGUI AtackPower;
    public TextMeshProUGUI Speed;

    //public string Score1;
    //public string Score2;
    //public string Score3;

    public int HealthPointsBonus;
    public int AtackPowerBonus;
    public float SpeedBonus;

    public int coins;

    private void Awake()
    {
        HealthPointsBonus = PlayerPrefs.GetInt("HPBonus");
        AtackPowerBonus = PlayerPrefs.GetInt("ATKBonus");
        SpeedBonus = PlayerPrefs.GetFloat("SpeedBonus");
    }

    public void Update()
    {
        HealthPointsBonus = PlayerPrefs.GetInt("HPBonus");
        AtackPowerBonus = PlayerPrefs.GetInt("ATKBonus");
        SpeedBonus = PlayerPrefs.GetFloat("SpeedBonus");

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
        HealthPointsBonus += 10;
        PlayerPrefs.SetInt("HPBonus", HealthPointsBonus);
    }
    public void AtackPowerButton()
    {
        AtackPowerBonus += 1;
        PlayerPrefs.SetInt("ATKBonus", AtackPowerBonus);
    }
    public void SpeedButton()
    {
        SpeedBonus += 0.1f;
        PlayerPrefs.SetFloat("SpeedBonus", SpeedBonus);
    }
}
