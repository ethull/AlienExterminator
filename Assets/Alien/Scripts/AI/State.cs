using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// doesnt need to be a monobehaviour because we dont attach it as a game object
public class State
{
    // states the npc can be in
    public enum STATE
    {
        IDLE, GETHIT, ATTACK, PATROL, CHASE, CHASEATTACK, DEAD
    }
    
    // 'Events' - where we are in the running of a STATE.
    public enum EVENT
    {
        ENTER, UPDATE, EXIT
    };
    
    public STATE name; // To store the name of the STATE.
    protected EVENT stage; // To store the stage the EVENT is in.
    protected GameObject npc; // To store the NPC game object.
    protected Animator anim; // To store the Animator component.
    protected Transform player; // To store the transform of the player. This will let the guard know where the player is, so it can face the player and know whether it should be shooting or chasing (depending on the distance).
    protected State nextState; // This is NOT the enum above, it's the state that gets to run after the one currently running (so if IDLE was then going to PATROL, nextState would be PATROL).
    protected NavMeshAgent agent; // To store the NPC NavMeshAgent component.
    
    float visDist = 10.0f; // if player <10 distance from enemy, it can see it, so it moves to chase state
    float visAngle = 90.0f; // ... and if the player is within 70 degrees of the line of sight
    //float idleAttackDistance = 1.0f; // distance at which stop moving at attack; is this needed? gonna use the below one instead and attack
    float attackDistance = 5.0f; // distance at which we can attack
    
    // Constructor for State
    public State(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player)
    {
        npc = _npc;
        agent = _agent;
        anim = _anim;
        stage = EVENT.ENTER;
        player = _player;
    }
    
    // Phases as you go through the state.
    public virtual void Enter() { stage = EVENT.UPDATE; } // Runs first whenever you come into a state and sets the stage to whatever is next, so it will know later on in the process where it's going.
    public virtual void Update() { stage = EVENT.UPDATE; } // Once you are in UPDATE, you want to stay in UPDATE until it throws you out.
    public virtual void Exit() { stage = EVENT.EXIT; } // Uses EXIT so it knows what to run and clean up after itself.

    // The method that will get run from outside and progress the state through each of the different stages.
    public State Process()
    {
        if (stage == EVENT.ENTER) Enter();
        if (stage == EVENT.UPDATE) Update();
        if (stage == EVENT.EXIT)
        {
            Exit();
            return nextState; // Notice that this method returns a 'state'.
        }
        return this; // If we're not returning the nextState, then return the same state.
    }

    // Can the NPC see the player, using a simple Line Of Sight calculation?
    public bool CanSeePlayer()
    {
        Vector3 direction = player.position - npc.transform.position; // Provides the vector from the NPC to the player.
        float angle = Vector3.Angle(direction, npc.transform.forward); // Provide angle of sight.

        // If player is close enough to the NPC AND within the visible viewing angle...
        if(direction.magnitude < visDist && angle < visAngle)
        {
            return true; // NPC CAN see the player.
        }
        return false; // NPC CANNOT see the player.
    }

    public bool CanAttackPlayer()
    {
        Vector3 direction = player.position - npc.transform.position; // Provides the vector from the NPC to the player.
        if(direction.magnitude < attackDistance)
        {
            return true; // NPC IS close enough to the player to attack.
        }
        return false; // NPC IS NOT close enough to the player to attack.
    }
}