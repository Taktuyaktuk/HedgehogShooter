using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearestEnemyBehaviour : MonoBehaviour
{
    

    public List<Transform> EnemyList;
    public Transform NearestEnemy { get; set; }

    public int ActiveEnemy;
    public GameObject Enemies;


    private void Awake()
    {
        Enemies = GameObject.Find("---------Enemies---------");

        int enemy = Enemies.transform.childCount;
        for(int i =0; i < enemy; i++)
        {
            Transform child = Enemies.transform.GetChild(i);
            EnemyList.Add(child);
            ActiveEnemy++;
        }
    }

    private void Update()
    {
            ActiveEnemy = 0;
            EnemyList.Clear();
            int enemy = Enemies.transform.childCount;
            for(int i =0; i < enemy; i++ )
            {
                Transform child = Enemies.transform.GetChild(i);
            EnemyList.Add(child);
            ActiveEnemy++;
            }
    }
    private void OnEnable()
    {
        EventManager.DistanceChecker += Nearest;
    }

    private void OnDisable()
    {
        EventManager.DistanceChecker -= Nearest;
    }

    
    public void Nearest()
    {
        if (EnemyList.Count > 0)
        {
            float minimumDsitance = Mathf.Infinity;

            NearestEnemy = null;
            foreach (Transform enemy in EnemyList)
            {
                if (enemy != null)
                {
                    float distance = Vector3.Distance(transform.position, enemy.position);
                    if (distance < minimumDsitance)
                    {
                        minimumDsitance = distance;
                        NearestEnemy = enemy;
                    }
                }
                else
                {
                    continue;
                }
            }
        }
    }
}
