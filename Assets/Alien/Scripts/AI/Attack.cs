using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// SCRIPT UNUSED

// script for alien insects Attack state
public class Attack : State
{
    float rotationSpeed = 2.0f; // Set speed that NPC will rotate around to face player.
    AudioSource shoot; // To store the AudioSource component.
    public Attack(GameObject _npc, UnityEngine.AI.NavMeshAgent _agent, Animator _anim, Transform _player)
                : base(_npc, _agent, _anim, _player)
    {
        name = STATE.ATTACK; // Set name to correct state.
        shoot = _npc.GetComponent<AudioSource>(); // Get AudioSource component for shooting sound.
    }

    public override void Enter()
    {
        anim.SetTrigger("isShooting"); // Set shooting trigger to change animation.
        agent.isStopped = true; // Stop NPC so he can shoot.
        shoot.Play(); // Play shooting sound.
        base.Enter();
    }

    public override void Update()
    {
        // Calculate direction and angle to player.
        Vector3 direction = player.position - npc.transform.position; // Provides the vector from the NPC to the player.
        // Provides line of sight from the npc, using the direction vector
        float angle = Vector3.Angle(direction, npc.transform.forward); // Provide angle of sight.
        direction.y = 0; // Prevent character from tilting.

        // Rotate NPC to always face the player that he's attacking.
        npc.transform.rotation = Quaternion.Slerp(npc.transform.rotation,
                                            Quaternion.LookRotation(direction),
                                            Time.deltaTime * rotationSpeed);

        if(!CanAttackPlayer())
        {
            nextState = new Idle(npc, agent, anim, player); // If NPC can't attack player, set correct nextState.
            stage = EVENT.EXIT; // Set stage correctly as we are finished with Attack state.
        }
    }

    public override void Exit()
    {
        anim.ResetTrigger("isShooting"); // Makes sure that any events queued up for Shooting are cleared out.
        shoot.Stop(); // Stop shooting sound.
        base.Exit();
    }
}