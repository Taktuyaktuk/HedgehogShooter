using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsManager : MonoBehaviour
{
    [SerializeField]
    public PlayerStats PlayerStats;
    void Start()
    {
        PlayerStats.AttackPower += 25;
        PlayerStats.MaxHP += 1000;
        
    }
  
}
