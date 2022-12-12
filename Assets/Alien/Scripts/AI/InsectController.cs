using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InsectController : MonoBehaviour
{
    // hold insect state variables
    NavMeshAgent agent; // To store the NPC NavMeshAgent component.
    Animator anim; // To store the Animator component.
    public Transform player;  // To store the transform of the player. This will let the guard know where the player is, so it can face the player and know whether it should be shooting or chasing (depending on the distance).
    State currentState;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        agent = this.GetComponent<NavMeshAgent>(); // Grab agents NavMeshAgent.
        anim = this.GetComponent<Animator>(); // Grab agents Animator component.
        currentState = new Idle(this.gameObject, agent, anim, player); // Create our first state.
        //Debug.Log("Starting an aliens lifecycle");
    }

    void Update()
    {
        currentState = currentState.Process(); // Calls Process method to ensure correct state is set.
    }
}