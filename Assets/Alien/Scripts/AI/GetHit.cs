using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// script for alien insects GetHit state
public class GetHit : State
{

    private bool areWeMoving;
    //private Health health;
    public GetHit(GameObject _npc, UnityEngine.AI.NavMeshAgent _agent, Animator _anim, Transform _player)
                : base(_npc, _agent, _anim, _player)
    {
        name = STATE.GETHIT; // State set to match what NPC is doing.
        agent.speed = 3; // Speed is slightly lower after hit
        //agent.isStopped = false; // Set bool to determine NPC is moving.
    }
    
    public override void Enter()
    {
        areWeMoving = !agent.isStopped;
        // if we are hit while not walking
        if (areWeMoving){
            anim.SetTrigger("isWalkHit"); // Sets any current animation state back to Idle.
        } else {
        // if hit while walking
            anim.SetTrigger("isHit"); // Sets any current animation state back to Idle.
        }

        base.Enter(); // Sets stage to UPDATE.
    }

    public override void Update()
    {
        // if we can attack the player, continue to attack
        if (CanAttackPlayer()){
            nextState = new ChaseAttack(npc, agent, anim, player);
            stage = EVENT.EXIT; // The next time 'Process' runs, the EXIT stage will run instead, which will then return the nextState.
        }
        // if we can see the player, start chasing
        else if (CanSeePlayer())
        {
            nextState = new Chase(npc, agent, anim, player);
            stage = EVENT.EXIT; // The next time 'Process' runs, the EXIT stage will run instead, which will then return the nextState.
        // otherwise start patrolling
        } else {
            nextState = new Patrol(npc, agent, anim, player);
            stage = EVENT.EXIT; // The next time 'Process' runs, the EXIT stage will run instead, which will then return the nextState.
        }
        //TODO: Move staright to Chase if cant see player but they are within distance
    }

    public override void Exit()
    { 
        //if (areWeMoving){
        //    anim.ResetTrigger("isWalkHit"); // Sets any current animation state back to Idle.
        //} else {
        //// if hit while walking
        //    anim.ResetTrigger("isHit"); // Sets any current animation state back to Idle.
        //}
        // We dont want to reset animation, since it happens once, and we move straight to next state
        base.Exit();
    }

}