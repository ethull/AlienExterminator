using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// holds the players current items (weapons)
public class Inventory : MonoBehaviour
{
    // weapon prefabs
    public GameObject RifleGun;
    public GameObject PistolGun;
    public GameObject HeavyGun;
    public GameObject SniperGun;

    // current guns player has
    public List<GameObject> currentWeapons = new List<GameObject>();

    private GameObject weaponHolder;
    private Transform weaponSwitcherLocation;
    
    void Start(){
        Debug.Log("inventory script");
        //allWeapons = GameObject.FindGameObjectsWithTag("Gun");
        weaponHolder = GameObject.FindGameObjectWithTag("WeaponHolder");
        weaponSwitcherLocation = weaponHolder.GetComponent<WeaponSwitcher>().transform;
        AddWeapon(RifleGun);
        //currentWeapons.Add();
    }

    // do we currently have the weapon
    public bool HasWeapon(GameObject weaponPrefab){
        if (currentWeapons.Contains(weaponPrefab)){
            return true; 
        }
        return false;
    } 

    // add a weapon, to invenotry and then spawn it in WeaponSwitcher
    public bool AddWeapon(GameObject weaponPrefab){
        if (!HasWeapon(weaponPrefab)){
            currentWeapons.Add(weaponPrefab);
            GameObject spawnedWeapon = Instantiate(weaponPrefab, weaponSwitcherLocation);
            spawnedWeapon.transform.localPosition = Vector3.zero;
            spawnedWeapon.transform.localRotation = Quaternion.identity;
            return true;
        }
        return false;
    }
}