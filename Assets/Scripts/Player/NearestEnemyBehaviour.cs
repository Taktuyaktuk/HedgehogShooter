using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearestEnemyBehaviour : MonoBehaviour
{
    

    public List<Transform> EnemyList;
    public Transform NearestEnemy { get; set; }

    public int ActiveEnemy;/*{ get; set; }*/


    private void Awake()
    {
        GameObject[] ListOfEnemy = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(var enemy in ListOfEnemy)
        {
            EnemyList.Add(enemy.transform);
            ActiveEnemy++;
        }
    }

    private void Update()
    {
        GameObject[] ListOfEnemy = GameObject.FindGameObjectsWithTag("Enemy");
        if ( ActiveEnemy != ListOfEnemy.Length)
        {
            ActiveEnemy = 0;
            EnemyList.Clear();
            foreach (var enemy in ListOfEnemy)
            {
                EnemyList.Add(enemy.transform);
                ActiveEnemy++;
            }
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
