using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : StateMachineBehaviour
{
    private GameObject[] Waypoints;
    public float speed;

    int randomWaypoint;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Waypoints = GameObject.FindGameObjectsWithTag("Waypoints");
        randomWaypoint = Random.Range(0, Waypoints.Length);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, Waypoints[randomWaypoint].transform.position, speed * Time.deltaTime);

        if (Vector2.Distance(animator.transform.position, Waypoints[randomWaypoint].transform.position) < 0.1f)
        {
            randomWaypoint = Random.Range(0, Waypoints.Length);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    
}
