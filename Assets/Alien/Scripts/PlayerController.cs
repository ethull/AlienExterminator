using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Health health;
    private LevelManager levelManager;

    void Start()
    {
        health = GetComponent<Health>();
        health.OnDie += OnDie;
        health.OnDamaged += OnDamaged;
        
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
    }

    public void OnDamaged(float dmg, GameObject source)
    {
        //Debug.Log("Player damaged");
        // TODO add any animations
    }
    
    public void OnDie()
    {
        // if we die then tell levelManager to end the level
        levelManager.playerIsDead();
        //Debug.Log("Player dead");
        // TODO play game over screen
    }
}