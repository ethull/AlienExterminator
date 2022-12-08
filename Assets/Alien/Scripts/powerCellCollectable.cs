using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerCellCollectable : MonoBehaviour
{
    private GameObject shooter;
    public AudioClip pickupSound; //Pickup sound
    //float removeTime = 3.0f;

    //Start is called before the first frame update
    void Start()
    {
        shooter = GameObject.Find("Player Camera"); //Find the tripod
        //Destroy(gameObject, removeTime); //destory the object after 2s
    }

    //Update is called once per frame
    void Update()
    {
        //Rotate the powercell on the y axis, at 30degrees/second
        //Since Update is called once per frame, if game runs at 100 frames per second (100 game loops per second) Update() will rotate the obj 30*100 times a second
        //Time.detaTime is a fraction of one/(total fps), so this adjusts (reduces) rotation speed relative to the number of frames per second
        //This forces the motion to follow real world time rather than running on different speed for different computers (because diff computers have diff fps)
        transform.Rotate(new Vector3 (0, 30, 0) * Time.deltaTime);
    }
    
    //When the powercell collides with the Player
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            //Play a sound when the powercell is picked up
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);
            //Increase number of powercells the shooter has
            shooter.GetComponent<shooter>().increaseCells();
            Destroy(gameObject);//Destroy self
        }
    }
}
