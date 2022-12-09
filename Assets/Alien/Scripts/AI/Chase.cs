using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chase : State
{
    public Chase(GameObject _npc, UnityEngine.AI.NavMeshAgent _agent, Animator _anim, Transform _player)
                : base(_npc, _agent, _anim, _player)
    {
        name = STATE.CHASE; // State set to match what NPC is doing.
        agent.speed = 4; // Speed set to make sure NPC appears to be running.
        agent.isStopped = false; // Set bool to determine NPC is moving.
    }

    public override void Enter()
    {
        anim.SetTrigger("isWalking"); // Set running trigger to change animation.
        base.Enter();
    }

    public override void Update()
    {
        agent.SetDestination(player.position);  // Set goal for NPC to reach but navmesh processing might not have taken place, so...
        if (agent.hasPath) {                       // ...check if agent has a path yet.
            if (CanAttackPlayer()) {
                nextState = new ChaseAttack(npc, agent, anim, player); // If NPC can attack player, set correct nextState.
                stage = EVENT.EXIT; // Set stage correctly as we are finished with Chase state.
            }
            // If NPC can't see the player, switch back to Patrol state.
            else if (!CanSeePlayer()) {
                nextState = new Patrol(npc, agent, anim, player); // If NPC can't see player, set correct nextState.
                stage = EVENT.EXIT; // Set stage correctly as we are finished with Chase state.
            }
            //TODO add state for when hit (GetHit)
        }
    }

    public override void Exit()
    {
        anim.ResetTrigger("isWalking"); // Makes sure that any events queued up for Running are cleared out.
        base.Exit();
    }
}