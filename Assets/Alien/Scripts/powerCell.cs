using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerCell : MonoBehaviour
{
    public GameObject explode;
    private GameObject tripod;
    float removeTime = 3.0f;

    //Start is called before the first frame update
    void Start()
    {
        tripod = GameObject.Find ("tripod"); //Find the tripod
        Destroy(gameObject, removeTime); //Destory the object after 2s
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy") {
            //Instantiate the explosion
            Instantiate(explode, transform.position, transform.rotation);
            //Reduce the tripod's health
            tripod.GetComponent<triPodHealth>().reduceHealth();
            Destroy(gameObject);//Destroy self
        }
        if (other.gameObject.tag == "Box") {
            //Instantiate the explosion
            Instantiate(explode, transform.position, transform.rotation);
            Destroy(other.gameObject); //Destroy the other object
            Destroy(gameObject); //Destroy self
        }
    }

    void OnDestroy()
    {
        //Create an explosion at the position where the powercell is destroyed
        Instantiate(explode, transform.position, transform.rotation);
    }
}
