using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

// Repersents the finite state machine for enemys
// this class is the parent class for all enemy states
// class doesnt need to be a monobehaviour because we dont attach it as a game object
//  and we want to instantiate it
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
        ENTER, UPDATE, EXIT, OVER
    };
    
    public STATE name; // To store the name of the STATE.
    protected EVENT stage; // To store the stage the EVENT is in.
    protected GameObject npc; // To store the NPC game object.
    protected Animator anim; // To store the Animator component.
    protected Transform player; // To store the transform of the player. This will let the guard know where the player is, so it can face the player and know whether it should be shooting or chasing (depending on the distance).
    protected State nextState; // This is NOT the enum above, it's the state that gets to run after the one currently running (so if IDLE was then going to PATROL, nextState would be PATROL).
    protected NavMeshAgent agent; // To store the NPC NavMeshAgent component.
    
    float visDist = 15.0f; // if player <10 distance from enemy, it can see it, so it moves to chase state
    float visAngle = 270.0f; // ... and if the player is within 70 degrees of the line of sight
    //float idleAttackDistance = 1.0f; // distance at which stop moving at attack; is this needed? gonna use the below one instead and attack
    float attackDistance = 7.0f; // distance at which we can attack
    float stopDistance = 1.5f; // distance from player in which we stop following

    // Constructor for State
    public State(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player)
    {
        npc = _npc;
        agent = _agent;
        anim = _anim;
        stage = EVENT.ENTER;
        player = _player;
    }
    
    // --- State lifetime/stage methods
    
    // These are all the stages/processes for each state, in a lifecycle the state will go through every process
    // Stages as you go through the state.
    public virtual void Enter() { stage = EVENT.UPDATE; } // Runs first whenever you come into a state and sets the stage to whatever is next, so it will know later on in the process where it's going.
    public virtual void Update() { stage = EVENT.UPDATE; } // Once you are in UPDATE, you want to stay in UPDATE until it throws you out.
    public virtual void Exit() { stage = EVENT.EXIT; } // Uses EXIT so it knows what to run and clean up after itself.

    // The method that will get run from outside (from the controller) and progress the state through each of the different stages
    // This simplifies management of states (avoids lots of if statements)
    //  each state subclass has its own transitions and other components
    public State Process()
    {
        if (stage == EVENT.OVER) return this; // if the animation is over, we want to do nothing;
        if (stage == EVENT.ENTER) Enter();
        if (stage == EVENT.UPDATE) Update(); // this stage is run infinitely until a transition condition is passed
        if (stage == EVENT.EXIT)
        {
            Exit();
            return nextState; // Notice that this method returns a 'state'.
        }
        return this; // If we're not returning the nextState, then return the same state.
    }
    
    // --- Condition helper methods
    // Each state has transitions to other states, if uses conditions to determine when/what transition to do
    // The methods below are used to assist these transitions

    // Can the NPC see/detect the player, using a line Of sight calculation
    public bool CanSeePlayer()
    {
        // Provides the vector from the NPC to the player
        Vector3 direction = player.position - npc.transform.position;
        // Angle between (direction vector and npc's forward vector)
        //  this will be compared to the angle of vision (how wide the enemy can detect)
        float angle = Vector3.Angle(direction, npc.transform.forward);

        // If player is close enough to the NPC
        //  and within the visible viewing angle / field of vision
        if(direction.magnitude < visDist && angle < visAngle)
        {
            return true; // NPC CAN see the player.
        }
        return false; // NPC CANNOT see the player.
    }
    
    // Are we close enougth to the player to attack
    public bool CanAttackPlayer()
    {
        // Provides the vector from the NPC to the player
        Vector3 direction = player.position - npc.transform.position;
        if(direction.magnitude < attackDistance)
        {
            return true; // NPC IS close enough to the player to attack.
        }
        return false; // NPC IS NOT close enough to the player to attack.
        // we have to already be chaseing the player to attack, so detection angle is not required
    }
    
    // Is the insect close to player, used to stop it just in front of the player
    // NOT USED
    public bool IsCloseToPlayer(){
        Vector3 direction = player.position - npc.transform.position; // Provides the vector from the NPC to the player.
        if (direction.magnitude < stopDistance) return true;
        return false;
    }

    // --- Global transitions
    // These methods are called by insect controller when Health UnityActions are fired
    // These transition methods aren't in a state subclass because they are shared between all states
    
    // When called from any state, we change to GetHit state
    // Because we can get hit at any time
    public void OnDamaged(float dmg, GameObject src){
        // If we arent dead move to GetHit state
        if (name != STATE.DEAD){
            nextState = new GetHit(npc, agent, anim, player);
            Exit();
        }
    }

    // When called from any state, we change to Dead state
    public void OnDie(){
        nextState = new Dead(npc, agent, anim, player);
        Exit();
    }
}