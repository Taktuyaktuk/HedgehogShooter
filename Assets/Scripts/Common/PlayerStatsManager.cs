using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsManager : MonoBehaviour
{
    [SerializeField]
    public PlayerStats PlayerStats;
    [SerializeField]
    public PlayerMovement PlayerMovement;
    void Start()
    {
        PlayerStats.AttackPower += PlayerPrefs.GetInt("ATKBonus");
        PlayerStats.MaxHP += PlayerPrefs.GetInt("HPBonus");
        PlayerMovement._moveSpeed += PlayerPrefs.GetFloat("SpeedBonus");
    }
}
