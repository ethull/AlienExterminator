using UnityEngine;

// Extends Pickup with weapon functionality
public class WeaponPickup : Pickup
{
    // prefab of weapon that we are gonna pick up
    public GameObject WeaponPrefab;

    protected override void Start()
    {
        base.Start();

        // Set all children layers to default (to prefent seeing weapons through meshes)
        foreach (Transform t in GetComponentsInChildren<Transform>())
        {
            if (t != transform)
                t.gameObject.layer = 0;
        }
    }

    protected override void OnPicked(GameObject player)
    {
        // add the weapon to the player inventory
        Inventory Inventory = player.GetComponent<Inventory>();
        PlayPickupFeedback();
        // if we do add the weapon (if we dont already have it) then switch to it
        if (Inventory.AddWeapon(WeaponPrefab)){
            player.GetComponentInChildren<WeaponSwitcher>().SwitchToNewWeapon();
        }
        Destroy(gameObject);
    }
}