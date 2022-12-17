using System.Collections;
using UnityEngine;

// manages progress of the level and spawning of enemies
public class LevelManager : MonoBehaviour
{
    private int currentLevel;
    private CurrentSceneManager currentSceneManager;

    public float spawnTime; // time between enemy spawns
    public float numEnemies; // num of enemies that have to die to clear level
    public float spawned = 0;
    public float killed = 0;

    public bool isWin() { return killed == numEnemies; }
    
    public GameObject player;
    public Inventory playerInventory;
    
    // ref to insect spawner
    private InsectSpawner insectSpawner;
    
    public AudioClip levelClearSfx;
    public AudioClip gameOverSfx;

    // Start is called before the first frame update
    void Start()
    {
        currentLevel = MainManager.Instance.currentLevel;
        currentSceneManager = GameObject.FindGameObjectWithTag("MainManager").GetComponent<CurrentSceneManager>();
        insectSpawner = GameObject.FindGameObjectWithTag("AlienSpawner").GetComponent<InsectSpawner>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerInventory = player.GetComponent<Inventory>();
        setParams();
        spawnLoop();
    }
    
    void Update(){
    }

    // if the player dies then we fail the level
    public void playerIsDead(){
        AudioSource.PlayClipAtPoint(gameOverSfx, player.transform.position);

        // no need to update any persistent data, since we lose weapons when we die

        // Wait x secs and then load MainMenu Scene with gameover menu
        StartCoroutine(End("gameover"));
    }
    
    // if all the enemies are dead, we win the game
    void levelCleared(){
        AudioSource.PlayClipAtPoint(levelClearSfx, player.transform.position);
        // update main manager persistent data and get it to save it
        MainManager.Instance.clearedLevels[MainManager.Instance.currentLevel-1] = true;
        MainManager.Instance.obtainedWeapons = playerInventory.GetCurrentWeapons();
        //printArray(MainManager.Instance.obtainedWeapons);
        MainManager.Instance.WriteSave();
        
        // Wait x secs and then load MainMenu Scene with levelclear menu
        StartCoroutine(End("levelclear"));
    }
    
    // end the scene (runs as a coroutine so we can wait before changing scene)
    IEnumerator End(string result){
         yield return new WaitForSeconds(3);
         if (result == "levelclear") currentSceneManager.LevelClear();
         else if (result == "gameover") currentSceneManager.GameOver();
     }
    
    // Set difficulty params relative to level number
    void setParams(){
        switch(currentLevel){
            case 1:
                spawnTime = 3;
                numEnemies = 10;
                break;
            case 2:
                spawnTime = 3;
                numEnemies = 25;
                break;
            case 3:
                spawnTime = 2;
                numEnemies = 50;
                break;
        }
    }
    
    // level loop, for spawning enemies
    void spawnLoop(){
        // sometimes SpawnInsect() is run before the script runs Start(), so it cant setup its vars
        if(insectSpawner.spawners.Length == 0) insectSpawner.Start();
        StartCoroutine("Spawn");
    }

    // TODO adjust spawnTime relative to progress in level
    IEnumerator Spawn()
    {
        insectSpawner.SpawnInsect();
        spawned++;
        yield return new WaitForSeconds(spawnTime);
        // if we still have enemies to spawn
        if (spawned < numEnemies){
            StartCoroutine("Spawn");
        }
    }
    
    // called by enemy controllers when an enemy is killed
    public void enemyKilled(){
        killed += 1;
        //Debug.Log("enemy killed: " + killed);
        //Debug.Log("have we won?: " + isWin());
        if (isWin()){
            levelCleared();
        }
    }
    
    // test method for data to be written, change bool[]/string[] to test diff save data
    private void printArray(string[] arr){
        Debug.Log("printing arr: "+arr);
        for (int i=0; i<arr.Length; i++) Debug.Log("item "+i+": "+arr[i]);
    }
}