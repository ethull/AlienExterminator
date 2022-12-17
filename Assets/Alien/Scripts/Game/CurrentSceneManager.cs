using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

// this class manages the current scene
public class CurrentSceneManager : MonoBehaviour
{

    public void LoadLevel(int levelNum)
    {
        switch(levelNum){
            case 1:
                // step the currentLevel before loading the scene, so LevelManager can set difficulty params
                MainManager.Instance.currentLevel = 1;
                SceneManager.LoadScene("level01");
                break;
            case 2:
                MainManager.Instance.currentLevel = 2;
                SceneManager.LoadScene("level02");
                break;
            case 3:
                MainManager.Instance.currentLevel = 3;
                SceneManager.LoadScene("level03");
                break;
        }
    }

    // If game is running in editor exit playmode, if running in build mode quit app
    public void QuitGame()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }

    // methods called by LevelManager

    public void GameOver(){
        // set the next menu to show after MainMenu scene is loaded
        MainManager.targetMenu = "GameOver";
        // unlock cursor and show it (since FIO locks it in the level)
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("MainMenu");
    }
    
    public void LevelClear(){
        MainManager.targetMenu = "LevelClear";
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("MainMenu");
    }
    
    public void QuitFromPauseMenu(){
        MainManager.targetMenu = "Start";
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("MainMenu");
    }
}