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

    public GameObject Target;
    
    protected Health health;
    private LevelManager levelManager;

    public AudioClip InsectAttackSfx;
    public AudioClip InsectDamageSfx;
    public AudioClip InsectDeathSfx;

    public GameObject InsectDamageVfx;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        agent = this.GetComponent<NavMeshAgent>(); // Grab agents NavMeshAgent.
        anim = this.GetComponent<Animator>(); // Grab agents Animator component.
        currentState = new Idle(this.gameObject, agent, anim, player); // Create our first state.
        // health needs to be accessed here, becaus it cant be accessed in State
        //  since this script is attached to the Alien (State does not have MonoBehaviour)
        health = this.GetComponent<Health>();
        
        // Subscribe the health unity actions, so we know when the insect is damaged or dead
        health.OnDamaged += OnDamaged;
        health.OnDie += OnDie;

        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
    }

    void Update()
    {
        currentState = currentState.Process(); // Calls Process method to ensure correct state is set.
        GetComponent<SphereCollider>().enabled = currentState.name == State.STATE.CHASEATTACK;
    }

    // below methods needs to be called here because State class is not of type MonoBehaviour
    // hence it cant access untiy methods, like Destroy() and UnityAction subscription

    // When called from any state, we change to GetHit state
    // Because we can get hit at any time
    public void OnDamaged(float dmg, GameObject src)
    {
        GameObject insectVfxInstance = Instantiate(InsectDamageVfx, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        Destroy(insectVfxInstance, 3);
        AudioSource.PlayClipAtPoint(InsectDamageSfx, transform.position);
        currentState.OnDamaged(dmg, src);
    }

    // When called from any state, we change to Dead state
    public void OnDie()
    {
        AudioSource.PlayClipAtPoint(InsectDeathSfx, transform.position);
        currentState.OnDie();
        // Destroy gameObject after x seconds (after animation)
        Destroy(gameObject, 2.11f);
        // Tell level manager that an enemy has died
        levelManager.enemyKilled();
    }

    public void Attack(){
        if (Target != null){
            //Debug.Log(gameObject);
            //Debug.Log(Time.time);
            Target.GetComponent<Health>().TakeDamage(5, gameObject);
            AudioSource.PlayClipAtPoint(InsectAttackSfx, transform.position);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")){
            Target = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player")){
            Target = null;
        }
    }
}