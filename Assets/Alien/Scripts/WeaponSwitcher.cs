using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// weapon switcher
// allows to switch between all weapons that are in its children
public class WeaponSwitcher : MonoBehaviour
{
    public int selectedWeapon = 0; 
    public Gun selectedWeaponRef;

    void Start()
    {
        // Choose a weapon to start with
        SelectWeapon();
    }

    void Update()
    {
        SwitchWeapon();
    }
    
    // Switch to new weapon after a its is picked up
    public void SwitchToNewWeapon(){
        selectedWeapon = transform.childCount - 1;
        SelectWeapon();
    }
    
    // Check input for what weapon the player has selected
    void SwitchWeapon()
    {
        int previousSelectedWeapon = selectedWeapon;

        // select by scrollwheel
        // if we are scrolling down
        if (Input.GetAxis("Mouse ScrollWheel") < 0f){
            //go back to the first weapon
            if (selectedWeapon >= transform.childCount - 1)
                selectedWeapon = 0;
            else
                selectedWeapon++;
        }
        // if we are scrolling up
        if (Input.GetAxis("Mouse ScrollWheel") > 0f){
            //go back to the last weapon
            if (selectedWeapon <= 0)
                selectedWeapon = transform.childCount - 1;
            else
                selectedWeapon--;
        }

        // select by number
        if (Input.GetKeyDown(KeyCode.Alpha1)) selectedWeapon = 0;
        // make sure we have at least 2 weapons
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2) selectedWeapon = 1;
        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3) selectedWeapon = 2;
        if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4) selectedWeapon = 3;

        // if new weapon select it
        if (previousSelectedWeapon != selectedWeapon){
            SelectWeapon(); 
        };
    }
    
    // enable selected weapon and disable the others
    void SelectWeapon()
    {
        int i = 0;
        // for each transform that is a child of the current transform (all the child guns of weapon holder)
        foreach (Transform weapon in transform)
        {
            // only one weapon can be selected at a time
            if (i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
                selectedWeaponRef = weapon.gameObject.GetComponent<Gun>();
            }
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}