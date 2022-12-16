using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// class to spawn insects, LevelManager calls the spawn method
public class InsectSpawner : MonoBehaviour
{
    public GameObject insect; // Insect prefab
    public float max = -3; // Max x/z spawn position
    public float min = 3; // Min x/z spawn position
    public GameObject beam; // Beam of light used to spawn insects from the sky

    // Create a list of spawn locations
    public GameObject[] spawners;
    // Create a list of spawned insects
    public List<GameObject> insects = new List<GameObject>();
        
    public void Start()
    {
        // Add all spawn locations to the list
        spawners = GameObject.FindGameObjectsWithTag("Spawn");
    }
    
    // Spawn a single enemy
    public void SpawnInsect()
    {
        // Choose a random spawn location
        Transform spawnLocation = spawners[Random.Range(0, spawners.Length)].transform;

        //Debug.Log("Spawning alien no: "+spawned);
        // add randomness so they spawn slightly apart
        //Debug.Log(Time.timeScale);
        float xpos = spawnLocation.position.x + Random.Range(min, max + 1);
        float zpos = spawnLocation.position.z + Random.Range(min, max + 1);
        GameObject spawnedInsect = Instantiate(beam, new Vector3(xpos, spawnLocation.position.y, zpos), Quaternion.Euler(0,Random.Range (-90F, 90F),0)) as GameObject;
        insects.Add(spawnedInsect);
    }
}