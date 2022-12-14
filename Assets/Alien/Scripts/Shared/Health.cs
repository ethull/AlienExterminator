using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public float MaxHealth = 10f; // set default health, if its not set in the editor
    public UnityAction<float, GameObject> OnDamaged;
    public UnityAction OnDie;

    public float CurrentHealth = 0f;
    
    public bool IsDead = false;
    
    void Start()
    {
        CurrentHealth = MaxHealth;
    }
    
    public void TakeDamage(float damage, GameObject damageSource)
    {
        Debug.Log("Health: x damage taken from y:  " + damage + " " + damageSource);
        float healthBefore = CurrentHealth;
        CurrentHealth -= damage;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0f, MaxHealth);

        // call OnDamage action
        float trueDamageAmount = healthBefore - CurrentHealth;
        if (trueDamageAmount > 0f)
        {
            OnDamaged?.Invoke(trueDamageAmount, damageSource);
        }

        HandleDeath();
    }
    
    public void Kill()
    {
        CurrentHealth = 0f;

        // call OnDamage action
        OnDamaged?.Invoke(MaxHealth, null);

        HandleDeath();
    }
    
    private void HandleDeath()
    {
        if (IsDead)
            return;

        // call OnDie action
        if (CurrentHealth <= 0f)
        {
            IsDead = true;
            OnDie?.Invoke();
        }
    }
}