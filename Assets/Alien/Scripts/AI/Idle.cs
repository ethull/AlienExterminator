using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// script for alien insects Idle state
public class Idle : State
{
    public Idle(GameObject _npc, UnityEngine.AI.NavMeshAgent _agent, Animator _anim, Transform _player)
                : base(_npc, _agent, _anim, _player)
    {
        name = STATE.IDLE; // Set name of current state.
    }

    public override void Enter()
    {
        anim.SetTrigger("isIdle"); // Sets any current animation state back to Idle.
        base.Enter(); // Sets stage to UPDATE.
    }

    public override void Update()
    {
        // if we can see the player, start chasing
        if (CanSeePlayer())
        {
            nextState = new Chase(npc, agent, anim, player);
            stage = EVENT.EXIT; // The next time 'Process' runs, the EXIT stage will run instead, which will then return the nextState.
        }
        // At random, decide if to start patrolling
        else if(Random.Range(0,100) < 30)
        {
            nextState = new Patrol(npc, agent, anim, player);
            stage = EVENT.EXIT; // The next time 'Process' runs, the EXIT stage will run instead, which will then return the nextState.
        }
    }

    public override void Exit()
    {
        anim.ResetTrigger("isIdle"); // Makes sure that any events queued up for Idle are cleared out.
        base.Exit();
    }
}