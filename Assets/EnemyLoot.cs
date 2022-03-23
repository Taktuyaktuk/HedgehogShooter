using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLoot : MonoBehaviour
{
    EnemyAbstract Enemy;
    public GameObject Loot;
    Vector3  Pos;
   
    private void Awake()
    {
        Enemy = this.GetComponentInParent<EnemyAbstract>();
    }
    void Update()
    {
        LootGenerator();
    }

    void LootGenerator()
    {
        if (Enemy.HP <= 0)
        {
            int Rnd = Random.Range(1, 4);
            if (Rnd == 1)
            {
                Pos = GetComponent<Transform>().transform.localPosition;
                Instantiate(Loot, Pos, Quaternion.identity); ;
            }
        }
    }
}
