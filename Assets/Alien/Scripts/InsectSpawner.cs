using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsectSpawner : MonoBehaviour
{
    public float spawnTime = 100; //Spawn Time
    public float spawnLimit = 3;
    public float spawned = 0;
    public GameObject insect; //Insect prefab
    public float max = -3; //Max x/z spawn position
    public float min = 3; //Min x/z spawn position

    // Create a list of spawned insects
    private List<GameObject> insects = new List<GameObject>();
        
    // Start is called before the first frame update
    void Start()
    {
        //Start the spawn update
        StartCoroutine("Spawn");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator Spawn()
    {
        Debug.Log("Spawning alien no: "+spawned);
        //Wait spawnTime
        //Spawn prefab is apple
        //GameObject prefab = insect;
        //if (Random.Range(0,100) < 30){
        //  prefab = bomb;
        //}
        //Spawn prefab at randomc position
        // add randomness so they spawn slightly apart
        Debug.Log(Time.timeScale);
        float xpos = transform.position.x + Random.Range(min, max + 1);
        float zpos = transform.position.z + Random.Range(min, max + 1);
        GameObject spawnedInsect = Instantiate(insect, new Vector3(xpos, transform.position.y, zpos), Quaternion.Euler(0,0, Random.Range (-90F, 90F))) as GameObject;
        insects.Add(spawnedInsect);
        spawned++;

        yield return new WaitForSeconds(spawnTime);

        // If we Start the spawn again
        if (spawned < spawnLimit) {
            StartCoroutine("Spawn");
        }
        // TODO move to the level complete scene
    }
}