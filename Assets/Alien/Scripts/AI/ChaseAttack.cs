using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseAttack : State
{
    public ChaseAttack(GameObject _npc, UnityEngine.AI.NavMeshAgent _agent, Animator _anim, Transform _player)
                : base(_npc, _agent, _anim, _player)
    {
        name = STATE.CHASEATTACK; // State set to match what NPC is doing.
        agent.speed = 2; // Moves slower while attacking
        agent.isStopped = false; // Set bool to determine NPC is moving.
    }

    public override void Enter()
    {
        anim.SetTrigger("isWalkAttacking"); // Set running trigger to change animation.
        base.Enter();
    }

    public override void Update()
    {
        agent.SetDestination(player.position);  // Set goal for NPC to reach but navmesh processing might not have taken place, so...
        // TODO add code to reduce player health here
        if (agent.hasPath) {                       // ...check if agent has a path yet.
            // If we cant see the player go back to patrolling
            if (!CanSeePlayer()) {
                nextState = new Patrol(npc, agent, anim, player); // If NPC can't see player, set correct nextState.
                stage = EVENT.EXIT; // Set stage correctly as we are finished with Chase state.
            }
            // If we cant attack the player anymore, go back to chasing
            if (!CanAttackPlayer()) {
                nextState = new Chase(npc, agent, anim, player); // If NPC can attack player, set correct nextState.
                stage = EVENT.EXIT; // Set stage correctly as we are finished with Chase state.
            }
            //TODO add state for when hit (GetHit)
        }
    }

    public override void Exit()
    {
        anim.ResetTrigger("isWalkAttacking"); // Makes sure that any events queued up for Running are cleared out.
        base.Exit();
    }
}