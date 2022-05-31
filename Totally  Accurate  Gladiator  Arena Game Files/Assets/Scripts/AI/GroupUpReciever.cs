using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupUpReciever : StateMachineBehaviour
{
    private WalkToPosition WTP;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        WTP = animator.gameObject.GetComponent<WalkToPosition>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Transform position = animator.gameObject.GetComponent<AIData>().Sender.transform;
        AIData data = animator.gameObject.GetComponent<AIData>();
        WTP.Walk(data.agent, position);
    }
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}