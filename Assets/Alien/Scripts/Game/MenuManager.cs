using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// manage which screen of the menu is displayed
// decide what menu to display initially when MainMenu scene is loaded
// allow menus to change menu
public class MenuManager : MonoBehaviour
{
    public GameObject Menus;
    public GameObject StartMenu;
    public GameObject LevelSelectMenu;
    public GameObject GameOverMenu;
    public GameObject LevelClearMenu;
    
    void Start () {
        // TODO make Finds more efficient (via children)
        Menus = GameObject.Find("Menus");
        StartMenu = Menus.transform.Find("StartMenu").gameObject;
        LevelSelectMenu = Menus.transform.Find("LevelSelectMenu").gameObject;
        LevelClearMenu = Menus.transform.Find("LevelClearMenu").gameObject;
        GameOverMenu = Menus.transform.Find("GameOverMenu").gameObject;
        
        // since this is called when MainMenu is loaded
        //  decide what scene we should start on
        SelectMenu(MainManager.targetMenu);
    }

    // load a menu from the menu scene
    public void SelectMenu(string menuName){
        //Debug.Log("Selecting Menu: " + menuName);
        //Debug.Log(LevelClearMenu.GetComponentInChildren<Button>());

        string currentSceneName = SceneManager.GetActiveScene().name;
        //if we are not in the mainmenu switch to main menu
        switch(menuName){
            case "Start":
                StartMenu.SetActive(true);
                LevelSelectMenu.SetActive(false);
                LevelClearMenu.SetActive(false);
                GameOverMenu.SetActive(false);
                break;
            case "LevelSelect":
                StartMenu.SetActive(false);
                LevelSelectMenu.SetActive(true);
                LevelClearMenu.SetActive(false);
                GameOverMenu.SetActive(false);
                break;
            case "LevelClear":
                StartMenu.SetActive(false);
                LevelSelectMenu.SetActive(false);
                LevelClearMenu.SetActive(true);
                GameOverMenu.SetActive(false);
                break;
            case "GameOver":
                StartMenu.SetActive(false);
                LevelSelectMenu.SetActive(false);
                LevelClearMenu.SetActive(false);
                GameOverMenu.SetActive(true);
                break;
        }
    }
    
    // tell main manager to reset game progress
    public void ResetProgress(){
        MainManager.Instance.ResetSave();
    }
}