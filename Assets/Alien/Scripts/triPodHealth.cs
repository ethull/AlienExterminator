using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triPodHealth : MonoBehaviour
{
    //Health of the Tripod
    private float health = 3;
    public GameObject smoke, flare;

    //Reduce the Tripods health, called by shooter
    public void reduceHealth()
    {
        health --;
    }

    //When the Tripod collides
    void OnCollisionEnter(Collision collision)
    {
        //When the Tripods health is 0, activate smoke and fire prefabs
        if (health <= 0){
            smoke.SetActive(true);
            flare.SetActive(true);
        }
    }
}
