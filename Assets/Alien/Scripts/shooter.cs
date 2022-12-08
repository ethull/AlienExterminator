using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooter : MonoBehaviour
{
    public GameObject powercell; //Link to the powerCell prefab
    public int no_cell = 1; //Number of powerCell owned
    public AudioClip throwSound; //Throw sound
    public float throwSpeed = 20; //Throw speed

    public void increaseCells(){
        no_cell++;
    }

    //Update is called once per frame
    void Update()
    {
        //Has the fire button been pressed
        if (Input.GetButtonDown ("Fire1") && no_cell > 0) {
            //Reduce the cell
            no_cell --;
            //Play throw sound
            AudioSource.PlayClipAtPoint(throwSound, transform.position);
            //Instantaite the powercell as a game object, at position of the shooter
            GameObject cell = Instantiate(powercell, transform.position, 
                transform.rotation) as GameObject;
            //Ask physics engine to ignore collison between
            // power cell and our FPSControler
            Physics.IgnoreCollision(transform.root.GetComponent<Collider>(),
                cell.GetComponent<Collider>(), true);
            //Give the powerCell a velocity of transform.forward (Vector3(0,0,1)) (so that it moves forward)
            cell.GetComponent<Rigidbody>().velocity = transform.forward * throwSpeed;
        }
    }
}
