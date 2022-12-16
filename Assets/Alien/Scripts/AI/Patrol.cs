using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq; // for Enumerable

// Constructor for Patrol state.
public class Patrol : State
{
    int currentIndex = -1;
    public int[] path;
    // we want System.random and not Unity random because want integers
    System.Random rnd = new System.Random();
    public Patrol(GameObject _npc, UnityEngine.AI.NavMeshAgent _agent, Animator _anim, Transform _player)
                : base(_npc, _agent, _anim, _player)
    {
        name = STATE.PATROL; // Set name of current state.
        agent.speed = 2; // How fast your character moves ONLY if it has a path. Not used in Idle state since agent is stationary.
        agent.isStopped = false; // Start and stop agent on current path using this bool.
    }

    public override void Enter()
    {
        // Generate a random path between waypoints
        path = Enumerable.Range(0, GameEnvironment.Singleton.Checkpoints.Count).OrderBy(c => rnd.Next()).ToArray();
        Debug.Log(path);
        //Debug.Log("Enumerable");
        //foreach (var item in path) {
        //    Debug.Log(item);
        //}
        
        //currentIndex = 0;
        // Choose a random waypoint to go to
        //while (randomIndex != lastIndex) randomIndex = Random.Range(0, GameEnvironment.Singleton.Checkpoints.Count);
        // make sure we dont go to the same index twice
        //lastIndex = randomIndex;
        //int currentIndex = randomIndex;

        //float lastDist = Mathf.Infinity; // Store distance between NPC and waypoints.

        // Calculate closest waypoint by looping around each one and calculating the distance between the NPC and each waypoint.
        //for (int i = 0; i < GameEnvironment.Singleton.Checkpoints.Count; i++)
        //{
        //    GameObject thisWP = GameEnvironment.Singleton.Checkpoints[i];
        //    float distance = Vector3.Distance(npc.transform.position, thisWP.transform.position);
        //    if(distance < lastDist)
        //    {
        //        currentIndex = i - 1; // Need to subtract 1 because in Update, we add 1 to i before setting the destination.
        //        lastDist = distance;
        //    }
        //}
        
        anim.SetTrigger("isWalking"); // Start agent walking animation.
        base.Enter();
    }

    public override void Update()
    {
        // Check if agent hasn't finished walking between waypoints.
        if(agent.remainingDistance < 1)
        {
            // If agent has reached end of waypoint list, go back to the first one, otherwise move to the next one.
            if (currentIndex >= GameEnvironment.Singleton.Checkpoints.Count - 1)
                currentIndex = 0;
            else
                currentIndex++;

            Debug.Log("alien patrol script u cunt");
            Debug.Log("GE checkpoints: "+GameEnvironment.Singleton.Checkpoints);
            Debug.Log("path: "+path);
            Debug.Log("path ci:"+path[currentIndex]);
            Debug.Log("GE wh path: "+GameEnvironment.Singleton.Checkpoints[path[currentIndex]].transform.position);
            Debug.Log("GE wh path: "+GameEnvironment.Singleton.Checkpoints[path[currentIndex]].transform.position);
            agent.SetDestination(GameEnvironment.Singleton.Checkpoints[path[currentIndex]].transform.position); // Set agents destination to position of next waypoint.
        }

        if (CanSeePlayer())
        {
            nextState = new Chase(npc, agent, anim, player);
            stage = EVENT.EXIT; // The next time 'Process' runs, the EXIT stage will run instead, which will then return the nextState.
        }
        //TODO add state for when hit (GetHit)
    }

    public override void Exit()
    {
        anim.ResetTrigger("isWalking"); // Makes sure that any events queued up for Walking are cleared out.
        base.Exit();
    }
}