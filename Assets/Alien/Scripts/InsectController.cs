using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class InsectController : MonoBehaviour
{
    // states the npc can be in
    public enum AIState
    {
        IDLE, PATROL, FOLLOW, ATTACK, FOLLOWATTACK,
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
    float visAngle = 30.0f; // ... and if the player is within 30 degrees of the line of sight
    float walkingAtkDis = 10.0f; // if player is <x distance from  enemy, it keeps following but it attacks at the same time.
    float idleAtkDis = 4.0f; // if player is <y distance from enemy,  it stops following and then attacks
    
    public Animator Animator;
    public AIState AiState { get; private set; }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
