using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    
    public float HP  = 100;
    public float AttackPower { get; set; } = 25;
    public int Level { get; set; }

   

    private void LateUpdate()
    {
        if(HP<= 0)
        {
            Destroy(gameObject);
        }
    }

}
