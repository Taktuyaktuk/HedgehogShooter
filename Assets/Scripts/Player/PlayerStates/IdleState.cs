using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class IdleState : StateMachineBehaviour
{
    public const string MOVE_STATE = "Move";
    const string FIRE_STATE = "Fire";

    PlayerMovement PlayerMoveCheck;
    EnemyManager m_enemyManager;


    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("IdleState");
        animator.ResetTrigger(MOVE_STATE);
        if (PlayerMoveCheck == null)
        {
            PlayerMoveCheck = GameObject.Find("Player").GetComponent<PlayerMovement>();
            Debug.Log("IdleState");
        }

        if (m_enemyManager == null)
        {
            m_enemyManager = EnemyManager.GetInstance();
        }

    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (PlayerMoveCheck._rigidbody.velocity != Vector3.zero) { animator.SetTrigger(MOVE_STATE); }
        else if (m_enemyManager.TargetExists()) animator.SetTrigger(FIRE_STATE);
    }
}
