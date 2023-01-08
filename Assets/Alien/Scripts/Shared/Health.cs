using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Health script, used by enemys and player
public class Health : MonoBehaviour
{
    public float MaxHealth = 10f; // set default health, if its not set in the editor
    // UnityActions: are subscribed to by enemy and player controllers
    // UnityActions v UnityEvents (Unity actions dont show up in the inspector), otherwise more of a choice of preference
    public UnityAction<float, GameObject> OnDamaged;
    public UnityAction OnDie;
    public UnityAction<float> OnHealed;

    public float CurrentHealth = 0f;
    
    public bool IsDead = false;

    // we dont want to heal if we are already at max health
    public bool CanPickup() => CurrentHealth < MaxHealth;
    
    void Start()
    {
        CurrentHealth = MaxHealth;
    }
    
    // damage the player
    public void TakeDamage(float damage, GameObject damageSource)
    {
        //Debug.Log("Health: x damage taken from y:  " + damage + " " + damageSource);
        float healthBefore = CurrentHealth;
        CurrentHealth -= damage;
        // Make sure Current health is between 0 and max health after takeing damage
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0f, MaxHealth);

        // call OnDamage action
        float trueDamageAmount = healthBefore - CurrentHealth;
        if (trueDamageAmount > 0f)
        {
            // invoke OnDamaged action, all subscribers will get updated
            OnDamaged?.Invoke(trueDamageAmount, damageSource);
        }

        HandleDeath();
    }
    
    // kill the player in one swoop (for testing/ future use)
    public void Kill()
    {
        CurrentHealth = 0f;

        // call OnDamage action
        OnDamaged?.Invoke(MaxHealth, null);

        // if our health is 0 then we are dead
        HandleDeath();
    }
    
    // handle the player dieing
    private void HandleDeath()
    {
        if (IsDead)
            return;

        // invoke OnDie action, all subscribers will get updated
        if (CurrentHealth <= 0f)
        {
            IsDead = true;
            OnDie?.Invoke();
        }
    }
    
    // Heal after a health pickup
    public void Heal(float healAmount)
    {
        float healthBefore = CurrentHealth;
        CurrentHealth += healAmount;
        // Make sure Current health is between 0 and max health after healing
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0f, MaxHealth);

        float trueHealAmount = CurrentHealth - healthBefore;
        if (trueHealAmount > 0f)
        {
            // invoke OnHeal action, not used atm
            OnHealed?.Invoke(trueHealAmount);
        }
        Debug.Log(CurrentHealth);
    }
}