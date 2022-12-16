using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Slider healthBar;
    public Slider alienBar;

    public Health player;
    public LevelManager aliens;
    
    // Start is called before the first frame update
    void Awake()
    {
        healthBar = transform.Find("HealthBar").GetComponent<Slider>();
        alienBar = transform.Find("EnemyProgress").GetComponent<Slider>();

        player = GameObject.Find("FirstPerson-AIO").GetComponent<Health>();
        aliens = GameObject.Find("LevelManager").GetComponent<LevelManager>();

        healthBar.maxValue = player.MaxHealth;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        alienBar.maxValue = aliens.numEnemies;
        
        healthBar.value = player.CurrentHealth;
        alienBar.value = aliens.numEnemies - aliens.killed;
    }
}
