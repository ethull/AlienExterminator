using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// class that controls the player
public class PlayerController : MonoBehaviour
{
    public Health health;
    private LevelManager levelManager;
    
    public AudioClip PlayerDamageSfx;
    public AudioClip PlayerDeathSfx;
    
    public GameObject PlayerDamageVfx;

    void Start()
    {
        // subscribe to player Health component UnityActions
        health = GetComponent<Health>();
        health.OnDie += OnDie;
        health.OnDamaged += OnDamaged;
        
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
    }

    public void OnDamaged(float dmg, GameObject source)
    {
        AudioSource.PlayClipAtPoint(PlayerDamageSfx, transform.position);
        // spawn blood on the floor
        GameObject playerVfxInstance = Instantiate(PlayerDamageVfx, new Vector3(transform.position.x, transform.position.y-1, transform.position.z), Quaternion.identity);
        Destroy(playerVfxInstance, 3);

        // TODO add any animations
    }
    
    public void OnDie()
    {
        AudioSource.PlayClipAtPoint(PlayerDeathSfx, transform.position);
        // if we die then tell levelManager to end the level
        levelManager.playerIsDead();
        //Debug.Log("Player dead");
        // TODO play game over screen
    }
}