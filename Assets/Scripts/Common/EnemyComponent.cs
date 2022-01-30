using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class EnemyComponent : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshAgent m_navmeshAgent;
    Animator m_animator;
    private void Start()
    {
        EnemyManager.GetInstance().RegisterEnemy(this);
        m_navmeshAgent = GetComponent<NavMeshAgent>();
        m_animator = GetComponent<Animator>();
    }


    //private void Update()
    //{
    //    if (!m_navmeshAgent.hasPath)
    //    {
    //        m_navmeshAgent.SetDestination(RandomNavmeshLocation(5));
    //    }
    //}
    private void OnDestroy()
    {
        if (EnemyManager.GetInstance())
        {
            EnemyManager.GetInstance().UnregisterEnemy(this);
        }
    }

    //public Vector3 RandomNavmeshLocation(float radius)
    //{
    //    Vector3 randomDirection = Random.insideUnitSphere * radius;
    //    randomDirection += transform.position;
    //    NavMeshHit hit;
    //    Vector3 finalPosition = Vector3.zero;
    //    if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
    //    {
    //        finalPosition = hit.position;
    //    }
    //    return finalPosition;
    //}
}
