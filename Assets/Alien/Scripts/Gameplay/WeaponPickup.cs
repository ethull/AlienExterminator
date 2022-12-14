using UnityEngine;

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
        Inventory Inventory = player.GetComponent<Inventory>();
        if (Inventory.AddWeapon(WeaponPrefab)){
            player.GetComponentInChildren<WeaponSwitcher>().SwitchToNewWeapon();
        }
        Destroy(gameObject);
    }
}