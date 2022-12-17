using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// script for alien insects Dead state
public class Dead : State
{

    private bool areWeMoving;
    //private Health health;
    public Dead(GameObject _npc, UnityEngine.AI.NavMeshAgent _agent, Animator _anim, Transform _player)
                : base(_npc, _agent, _anim, _player)
    {
        name = STATE.DEAD; // State set to match what NPC is doing.
        agent.isStopped = true; // Should stop moving as its dead
    }
    
    public override void Enter()
    {
        anim.SetTrigger("isDead"); // Sets any current animation state back to Idle.
        base.Enter(); // Sets stage to UPDATE.
    }

    public override void Update()
    {
        stage = EVENT.OVER; // The next time 'Process' runs, the EXIT stage will run instead, which will then return the nextState.
        //there is no exit as the object is destroyed after it dies, this is the last animation
    }

    public override void Exit()
    { 
        //anim.ResetTrigger("isDead");
        //base.Exit();
    }

}