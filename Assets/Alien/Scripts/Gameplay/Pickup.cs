//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

// class to manage pickup items (weapons and health)
public class Pickup : MonoBehaviour
{
    public float VerticalBobFrequency = 0.5f;
    public float BobbingAmount = 0.5f;
    public float RotatingSpeed = 90f;
    
    public AudioClip PickupSfx;
    public GameObject PickupVfx;

    //public AudioClip PickupSfx;
    //public GameObject PickupVfxPrefab;

    Vector3 startPos;
    //bool m_HasPlayedFeedback;

    protected virtual void Start()
    {
        // Remember start position for animation
        startPos = transform.position;
    }

    void Update()
    {
        // handle bobbing
        // calculate where we are in the current bob animation
        //  Mathf.Sin keeps numbers between -1 and 1 (so the animation will repeat)
        //  Time.time: time in secs since the start of animation, other variables are used to adjust bobbing parameters
        float bobbingAnimationPhase = ((Mathf.Sin(Time.time * VerticalBobFrequency) * 0.1f) + 0.5f) * BobbingAmount;
        // update transform position, relative to start position, and the last pos in the current bob animation
        transform.position = startPos + Vector3.up * bobbingAnimationPhase;

        // Handle rotating
        transform.Rotate(Vector3.up, RotatingSpeed * Time.deltaTime, Space.Self);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")){
            OnPicked(other.gameObject);
        }
    }

    // to be inherited by Health and Weapon pickup specific scripts
    protected virtual void OnPicked(GameObject playerController)
    {
        Debug.Log("picked up by: " + playerController);
        PlayPickupFeedback();
    }
    
    // play sound after pickup
    public void PlayPickupFeedback()
    {
        if (PickupSfx)
        {
            AudioSource.PlayClipAtPoint(PickupSfx, transform.position);
            GameObject playerVfxInstance = Instantiate(PickupVfx, transform.position, Quaternion.identity);
        }
    }
}