using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootGunPowPow : MonoBehaviour
{
    private Transform cameraPos;

    //currentHealth = currentHealth - damage; 
    // Start is called before the first frame update
    void Start()
    {
        cameraPos = transform.Find("HeadJoint").Find("Player Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // if left mouse button clicked
        {
            var hits = Physics.RaycastAll(cameraPos.position, cameraPos.forward, 1000); // list of everything you were pointing at
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
                    Destroy(closest.transform.gameObject); // destroy
                }
                

            }
        }
    }
}
