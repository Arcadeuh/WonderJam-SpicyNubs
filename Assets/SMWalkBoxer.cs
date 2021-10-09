using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMWalkBoxer : StateMachineBehaviour
{
    private Boxer boxer;
    Animator animator;

    IEnumerator Wait()
    {
        float time = Random.Range(1.0f, 10.0f);
        yield return new WaitForSeconds(time);
        animator.SetTrigger("IsIdling");
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(!this.animator) this.animator = animator; 
        if(!this.boxer) boxer = animator.gameObject.GetComponent<Boxer>();
        boxer.Walk();
        boxer.StartAnyCoroutine(Wait());
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boxer.StopWalking();
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
