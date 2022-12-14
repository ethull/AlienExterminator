using UnityEngine;

public class HealthPickup : Pickup
{
    public float HealAmount;

    // override parent onpicked class method
    protected override void OnPicked(GameObject player)
    {
        Health playerHealth = player.GetComponent<Health>();
        if (playerHealth && playerHealth.CanPickup())
        {
            playerHealth.Heal(HealAmount);
            //PlayPickupFeedback();
            Destroy(gameObject);
        }
    }
}