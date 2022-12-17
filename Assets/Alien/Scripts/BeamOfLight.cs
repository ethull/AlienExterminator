using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// spawn insects down in a beam of light (so they dont appear out of nowhere)
public class BeamOfLight : MonoBehaviour
{
    public InsectSpawner spawner;
    private float radius = 0;
    private bool spawned = false;
 
    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.Find("AlienSpawner").GetComponent<InsectSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        radius += Time.deltaTime * (spawned?-3f:3f);
        if (radius >=1 && !spawned)
        {
            GameObject spawnedInsect = Instantiate(spawner.insect, transform.position, transform.rotation) as GameObject;
            spawner.insects.Add(spawnedInsect);
            spawned = true;
        }

        if (spawned && radius<=0) Destroy(gameObject);

        transform.localScale = new(radius,200,radius);
    }
}
