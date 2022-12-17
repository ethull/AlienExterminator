using UnityEngine;

// Extends Pickup with heal functionality
public class HealthPickup : Pickup
{
    public float HealAmount = 10;

    // override parent onpicked class method
    protected override void OnPicked(GameObject player)
    {
        Health playerHealth = player.GetComponent<Health>();
        if (playerHealth && playerHealth.CanPickup())
        {
            playerHealth.Heal(HealAmount);
            PlayPickupFeedback();
            Destroy(gameObject);
        }
    }
}