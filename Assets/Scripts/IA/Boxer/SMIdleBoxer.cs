using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMIdleBoxer : StateMachineBehaviour
{
    Animator animator;
    private Coroutine waitCoroutine;

    IEnumerator Wait()
    {
        float time = Random.Range(1.0f, 10.0f);
        yield return new WaitForSeconds(time);
        animator.SetTrigger("IsWalking");
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(!this.animator) this.animator = animator;
        BoxerBehaviour boxer = animator.gameObject.GetComponent<BoxerBehaviour>();
        waitCoroutine = boxer.StartAnyCoroutine(Wait());
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        BoxerBehaviour boxer = animator.gameObject.GetComponent<BoxerBehaviour>();
        boxer.StopAnyCoroutine(waitCoroutine);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
