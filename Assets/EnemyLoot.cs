using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLoot : MonoBehaviour
{
    public GameObject Loot;
    Vector3  Pos;
   

    public void LootGenerator(Vector3 EnemyPos)
    {
            int Rnd = Random.Range(1, 4);
            if (Rnd == 1)
            {
                Instantiate(Loot, EnemyPos, Quaternion.identity); 
            }
    }
}
