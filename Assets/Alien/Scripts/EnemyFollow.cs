using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyFollow : MonoBehaviour
{
    public NavMeshAgent AlienCharacter;
    public Transform Player;

    //Patrolling
    public Vector3 walkPoint;
    bool walkPointRange;
    public float walkPointRange;

    //Attacking
    public float timebetweenAttacks;
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.FindGameObejctsWithTag("Player");
        AlienCharacter = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        playerInSightRange = physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) Chase();
        if (playerInSightRange && playerInAttackRange) Attack();

    }
    private void Patroling()
    {
        if (walkPointSet) SerachWalkPoint();
    }

    private void SerachWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

    }
    private void Chase()
    {

    }
    private void Attack()
    {

    }
   
}
