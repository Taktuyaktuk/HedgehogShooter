using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : StateMachineBehaviour
{
    public const string IDLE_STATE = "Fire";
    public float m_playerSpeed = 2;


    PlayerMovement PlayerMoveCheck;

   
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("MoveState");
        if (PlayerMoveCheck == null)
        {
            PlayerMoveCheck = GameObject.Find("Player").GetComponent<PlayerMovement>();
        }
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger(IDLE_STATE);
        if (PlayerMoveCheck._rigidbody.velocity == Vector3.zero) 
        { 
            animator.SetTrigger(IDLE_STATE); 
        }
    }

    public override void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Vector3 direction = PlayerMoveCheck._rigidbody.velocity;

        //Vector3 lookatPos = animator.transform.position + direction;
        //lookatPos.y = animator.transform.position.y;

        //animator.transform.LookAt(lookatPos);
        //animator.transform.position = animator.transform.position + (direction * m_playerSpeed * Time.deltaTime);
    }
}
