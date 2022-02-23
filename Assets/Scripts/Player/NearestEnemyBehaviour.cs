using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearestEnemyBehaviour : MonoBehaviour
{
    

    public List<Transform> EnemyList;
    public Transform nearestEnemy { get; set; }


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
        float minimumDsitance = Mathf.Infinity;



        nearestEnemy = null;
        foreach (Transform enemy in EnemyList)
        {
            float distance = Vector3.Distance(transform.position, enemy.position);
            if (distance < minimumDsitance)
            {
                minimumDsitance = distance;
                nearestEnemy = enemy;
            }
        }
        
    }


}
