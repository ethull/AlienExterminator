using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsectSpawner : MonoBehaviour
{
    public float spawnTime = 100; // Spawn Time
    public float spawnLimit = 3;
    public float spawned = 0;
    public GameObject insect; // Insect prefab
    public float max = -3; // Max x/z spawn position
    public float min = 3; // Min x/z spawn position
    public GameObject beam; // Beam of light used to spawn insects from the sky

    // Create a list of spawn locations
    public GameObject[] spawners;
    // Create a list of spawned insects
    public List<GameObject> insects = new List<GameObject>();
        
    void Start()
    {
        // Add all spawn locations to the list
        spawners = GameObject.FindGameObjectsWithTag("Spawn");

        // Start the spawn update
        StartCoroutine("Spawn");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator Spawn()
    {
        // Choose a random spawn location
        Transform spawnLocation = spawners[Random.Range(0, spawners.Length)].transform;

        //Debug.Log("Spawning alien no: "+spawned);
        // add randomness so they spawn slightly apart
        //Debug.Log(Time.timeScale);
        float xpos = spawnLocation.position.x + Random.Range(min, max + 1);
        float zpos = spawnLocation.position.z + Random.Range(min, max + 1);
        GameObject spawnedInsect = Instantiate(beam, new Vector3(xpos, spawnLocation.position.y, zpos), Quaternion.Euler(0,Random.Range (-90F, 90F),0)) as GameObject;
        //insects.Add(spawnedInsect);
        spawned++;

        yield return new WaitForSeconds(spawnTime);

        // If we Start the spawn again
        if (spawned < spawnLimit) {
            StartCoroutine("Spawn");
        }
        // TODO move to the level complete scene
    }
}