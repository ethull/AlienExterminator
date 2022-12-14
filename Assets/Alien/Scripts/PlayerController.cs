using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Health health;

    void Start()
    {
        health = GetComponent<Health>();
        health.OnDie += OnDie;
        health.OnDamaged += OnDamaged;
    }

    public void OnDamaged(float dmg, GameObject source)
    {
        //Debug.Log("Player damaged");
        // TODO add any animations
    }
    
    public void OnDie()
    {
        //Debug.Log("Player dead");
        // TODO play game over screen
    }
}