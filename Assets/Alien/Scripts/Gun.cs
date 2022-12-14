using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private Transform fpsCam;
    private Transform muzzlePos;
    public GameObject muzzleFlash;
    public GameObject impactEffect;
    
    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 10f;
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

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetButton("Fire") && Time.time >= nextTimeToFire) // if left mouse button clicked
        if (Input.GetMouseButtonDown(0) && Time.time >= nextTimeToFire) // if left mouse button clicked
        {
            // greater the firerate the less time between shots
            nextTimeToFire = Time.time + 1f/fireRate;
            Shoot();
        }
    }
    
    void Shoot () {
        //Debug.Log(muzzleFlash);
        //Debug.Log(fpsCam);
        //Instantiate(muzzleFlash, fpsCam);
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
            }
            
            GameObject impact = Instantiate(impactEffect, closest.point, Quaternion.LookRotation(closest.normal));
            Destroy(impact, 2f);
        }
    }
}
