using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// this script manages damage
// attach to anything that can take damage
public class Damage : MonoBehaviour
{
    public Health Health { get; private set; }
    
    void Awake()
    {
        // find the health component either at the same level, or higher in the hierarchy
        Health = GetComponent<Health>();
    }

    public void InflictDamage(float damage, GameObject damageSource)
    {
        if (Health)
        {
            // apply the damages
            Health.TakeDamage(damage, damageSource);
        }
    }
}