using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLoot : MonoBehaviour
{
    public GameObject Loot;
    public GameObject LootCoin;
    Vector3  Pos;
   

    public void LootGenerator(Vector3 EnemyPos)
    {
            int Rnd = Random.Range(1, 3);
            if (Rnd == 1)
            {
                Instantiate(Loot, EnemyPos, Quaternion.identity); 
            }
    }

    public void CoinLootGenerator (Vector3 EnemyPos)
    {
        Instantiate(LootCoin, EnemyPos, Quaternion.identity);
    }
}
