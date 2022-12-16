using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    // Start() and Update() methods deleted - we don't need them right now

    public static MainManager Instance;
    public int currentLevel;
    public bool[] clearedLevels; // index repersents level
    public string[] obtainedWeapons;
    
    // keep track of the current menu, used to set menus in MenuManager
    //  initialises with the Start menu
    public static string targetMenu = "Start";

    private void Awake()
    {
        //Debug.Log("main manager is awake");
        if (Instance != null){
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadSave();
    }
    
    [System.Serializable]
    class SaveData
    {
        public bool[] clearedLevels;
        public string[] obtainedWeapons;
    }

    public void WriteSave()
    {
        // create new instance of save data class
        SaveData data = new SaveData();
        data.clearedLevels = clearedLevels;
        data.obtainedWeapons = obtainedWeapons;
        //data.clearedLevels = new [] { 1, 2, 3 };
        //data.obtainedWeapons = new [] { "Rifle", "Pistol", "Heavy", "Sniper" };
        // 
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadSave()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            clearedLevels = data.clearedLevels;
            obtainedWeapons = data.obtainedWeapons;
        }
        // if we have no saved data, we cant have weapons and no cleared levels (since you only get your weapons if u clear)
        if (clearedLevels.Length == 0){
            SetDefaults();
        }
    }
    
    // if we have no save data then set defaults
    public void SetDefaults(){
        clearedLevels = new bool[] {false, false, false}; // no levels cleared
        obtainedWeapons = new string[] {"", "", "", ""}; // no weapons obtained
    }
    
    // NOT IMPLEMENTED
    // reset your save file
    public void ResetSave(){
        SetDefaults();
        WriteSave();
    }
}