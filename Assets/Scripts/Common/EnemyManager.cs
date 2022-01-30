using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    public List<EnemyComponent> m_enemyList = new List<EnemyComponent>();

    public void RegisterEnemy(EnemyComponent _enemy) { m_enemyList.Add(_enemy); }
    public void UnregisterEnemy(EnemyComponent _enemy) { m_enemyList.Remove(_enemy); }

    public bool TargetExists() { return m_enemyList.Count > 0; }

    public Vector3 GetNearestTarget(Vector3 _origin)
    {
        EnemyComponent nearestEnemy = null;
        float smallestDistance = float.MaxValue;

        foreach (EnemyComponent _enemy in m_enemyList)
        {
            float distance = (_enemy.transform.position - _origin).sqrMagnitude;
            if (distance < smallestDistance)
            {
                nearestEnemy = _enemy;
                smallestDistance = distance;
            }
        }

        return nearestEnemy == null ? Vector3.zero : nearestEnemy.transform.position;
    }
}
