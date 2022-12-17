using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// manage pause menu
public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    // refs to menu components
    public GameObject pauseMenuUI;
    public GameObject helpMenuUI;
    public GameObject hud;

    private CurrentSceneManager currentSceneManager;
    
    void Start(){
        currentSceneManager = GameObject.FindGameObjectWithTag("MainManager").GetComponent<CurrentSceneManager>();
    }

    void Update()
    {
        // if we press escape load menu
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }

        }

    }

    // show menu
    public void Resume()
    {
        hud.SetActive(true);
        pauseMenuUI.SetActive(false);
        helpMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false; 
    }

    // pause menu
    public void Pause()
    {
        hud.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // quit back to the MainMenu
    public void QuitGame()
    {
        currentSceneManager.QuitFromPauseMenu();
    }
    
    // swap to help menu
    public void DisplayHelpMenu(){
        pauseMenuUI.SetActive(false);
        helpMenuUI.SetActive(true);
    }
    
    // swap to pause menu
    public void BackToPauseMenu(){
        pauseMenuUI.SetActive(true);
        helpMenuUI.SetActive(false);
    }
}