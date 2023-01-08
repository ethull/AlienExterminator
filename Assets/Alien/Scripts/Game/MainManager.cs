using UnityEngine;
using System.IO;

// main static class, manage current menu and save data
public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public int currentLevel;
    public bool[] clearedLevels; // index repersents level
    public string[] obtainedWeapons;
    
    // keep track of the current menu, used to set menus in MenuManager
    //  initialises with the Start menu
    public static string targetMenu = "Start";

    // as soon as the attached gameobject is loaded into the scene run this method
    private void Awake()
    {
        //Debug.Log("main manager is awake");
        // if we change scene MainManager instance will already exist
        //  so we need to make sure only one Main manager instance exists
        if (Instance != null){
            Destroy(gameObject);
            return;
        }

        Instance = this;
        // mark this object to not be destroyed on changing scene
        //  so its properties are persisted between scenes
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
    
    // reset your save file
    public void ResetSave(){
        SetDefaults();
        WriteSave();
        LoadSave();
    }
}