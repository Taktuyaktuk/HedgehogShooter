using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireState : StateMachineBehaviour
{
   public bool m_canFire = false;

    PlayerMovement PlayerMoveCheck;
    EnemyManager m_enemyManager;
    WeaponComponent m_weaponComponent;


    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("FireState");
        if (PlayerMoveCheck == null)
        {
            PlayerMoveCheck = GameObject.Find("Player").GetComponent<PlayerMovement>();
        }
        if (m_enemyManager == null)
        {
            m_enemyManager = EnemyManager.GetInstance();
        }

        if (m_weaponComponent == null) { m_weaponComponent = animator.GetComponent<WeaponComponent>(); }
        m_canFire = true;
        animator.ResetTrigger(IdleState.MOVE_STATE);
    }


    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 target = m_enemyManager.GetNearestTarget(animator.transform.position);
        if (target != Vector3.zero)
        {
            //Hack for transform at feet height
            //target.y = animator.transform.position.y + 1;
            if (m_canFire == true)
            {
                m_canFire = false;
                m_weaponComponent.FireWeapon(animator.transform.position + Vector3.up, target);
                
            }
            //else
            //{
            //    animator.SetTrigger(MoveState.IDLE_STATE);
            //}
        }
        else
        {
            animator.SetTrigger(MoveState.IDLE_STATE);
        }

        if (PlayerMoveCheck._rigidbody.velocity != Vector3.zero)
        {
            animator.SetTrigger(IdleState.MOVE_STATE);
        }
    }



    public override void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        //Vector3 target = m_enemyManager.GetNearestTarget(animator.transform.position);
        //if (target != Vector3.zero)
        //{
        //    //Hack for transform at feet height
        //    target.y = animator.transform.position.y + 1;
        //    animator.gameObject.transform.LookAt(target);
        //}
    }
    
}
