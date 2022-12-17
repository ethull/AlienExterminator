using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Manage gun prefabs
public class Gun : MonoBehaviour
{
    public string gunName;
    // location fo cam and muzzle
    private Transform fpsCam;
    private Transform muzzlePos;

    // VFX effects
    public GameObject muzzleFlash;
    public GameObject impactEffect;

    // SFX effects
    public AudioClip ShootSfx;
    public AudioClip DestroySfx;
    
    // gun parameters, should be set in inspector for diff guns
    public float damage = 10f;
    public float range = 100f;
    //public float impactForce = 10f;
    public float fireRate = 30f;
    
    private float nextTimeToFire = 0f;

    //currentHealth = currentHealth - damage; 
    // Start is called before the first frame update
    void Start()
    {
        //cameraPos = transform.Find("HeadJoint").Find("Player Camera");
        fpsCam = GameObject.FindGameObjectWithTag("MainCamera").transform;
        muzzlePos = transform.Find("muzzle");
    }

    // manage firerate
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextTimeToFire) // if left mouse button clicked
        {
            // greater the firerate the less time between shots
            nextTimeToFire = Time.time + 1f/fireRate;
            Shoot();
        }
    }
    
    void Shoot () {
        GameObject flash = Instantiate(muzzleFlash, muzzlePos);
        Destroy(flash, 1f);

        var hits = Physics.RaycastAll(fpsCam.position, fpsCam.forward, range); // list of everything you were pointing at
        if (hits.Length > 0) // if anything was hit
        {
            RaycastHit closest = hits[0]; // keep track of the closest
            foreach (var hit in hits) // loop through the list
            {
                if (hit.distance < closest.distance) // if this object is closer than the previous closest
                {
                    closest = hit; // it becomes the new closest
                }
            }
            if (closest.transform.GetComponent<InsectController>()) // if the closest hit object is an insect
            {
                // If target is not dead (dont want to register damage as its dieing)
                if (!closest.transform.GetComponent<Health>().IsDead){
                    // we can the health rather than the state, because the health will call a UnityAction
                    closest.transform.GetComponent<Health>().TakeDamage(damage, gameObject);
                    //Destroy(closest.transform.gameObject); // destroy
                }
            // if we shoot a Crate then destroy it
            } else if (closest.transform.tag == "Destroyable") {
                Destroy(closest.transform.gameObject);
                AudioSource.PlayClipAtPoint(DestroySfx, closest.transform.position);
            }

            AudioSource.PlayClipAtPoint(ShootSfx, transform.position);
            
            // instantiate effect at location of object hit
            GameObject impact = Instantiate(impactEffect, closest.point, Quaternion.LookRotation(closest.normal));
            Destroy(impact, 2f);
        }
    }
}
