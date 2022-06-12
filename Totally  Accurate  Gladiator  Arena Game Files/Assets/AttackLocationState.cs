using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackLocationState : StateMachineBehaviour
{
    AIData data;
    public GameObject Crossing;
    public List<GameObject> crossings = new List<GameObject>();

    private bool once;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        once = false;
        data = animator.gameObject.GetComponent<AIData>();

        Crossing = GameObject.Find("Crossings");

        foreach (Transform child in Crossing.transform)
        {
            crossings.Add(child.gameObject);
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (once == false)
        {
            var x = Random.Range(0, crossings.Count);
            data.currentDestination = crossings[x].transform;
            data.agent.SetDestination(data.currentDestination.position);
            once = true;
            
        }
        

        var thedist = Vector3.Distance(data.gameObject.transform.position, data.currentDestination.position);
        if (thedist < 5)
        {
            animator.SetBool("AttackLoc", false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

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
