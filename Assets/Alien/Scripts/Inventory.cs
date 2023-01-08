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
        //allWeapons = GameObject.FindGameObjectsWithTag("Gun");
        weaponHolder = GameObject.FindGameObjectWithTag("WeaponHolder");
        weaponSwitcherLocation = weaponHolder.GetComponent<WeaponSwitcher>().transform;

        LoadWeapons();
        //currentWeapons.Add();
    }
    
    // load weapons that the player already has at the start of the level
    public void LoadWeapons(){
        string[] weapons = MainManager.Instance.obtainedWeapons;
        for (int i=0; i<weapons.Length; i++){
            switch(weapons[i]){
                case "Rifle":
                    AddWeapon(RifleGun);
                    break;
                case "Pistol":
                    AddWeapon(PistolGun);
                    break;
                case "Heavy":
                    AddWeapon(HeavyGun);
                    break;
                case "Sniper":
                    AddWeapon(SniperGun);
                    break;
            }
        }
        // If we have added no weapons, then it means the player has never played before
        //  so we give them the starter weapon (Rifle)
        if (currentWeapons.Count == 0) AddWeapon(RifleGun);
    }
    
    // return a list of strings with all the current weapons
    //  this is for LevelManager to save the weapons after the level is cleared
    public string[] GetCurrentWeapons(){
        string[] weapons = new string[4];
        for(int i=0; i<currentWeapons.Count; i++){
            weapons[i] = currentWeapons[i].GetComponent<Gun>().gunName;
        }
        return weapons;
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
            spawnedWeapon.transform.localPosition = Vector3.zero; // set local position to inventory postion (Vector3(0, 0, 0) relative to parent)
            spawnedWeapon.transform.localRotation = Quaternion.identity; // same rotation as parent
            return true;
        }
        return false;
    }
}