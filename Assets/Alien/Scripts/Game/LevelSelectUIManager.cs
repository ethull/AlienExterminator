using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectUIManager : MonoBehaviour
{
    GameObject levelButtons;
    void Start () {
        levelButtons = GameObject.FindGameObjectWithTag("LevelButtons");
    }

    // TODO make this more efficient: run it at start and get other func to call it after clearedLevels updates
    void Update () {
        // enable/disable buttons relative to number of levels cleared
        int i = 0;
        // for each transform (button)
        foreach (Transform button in levelButtons.transform)
        {
            //Debug.Log("level select: disabling buttons");
            // first button is enabled no matter what, also skips i++
            if (i == 0) {
                i++;
                continue;
            }; 
            // EG [true, false, false] -> [ButtonEnabled, Button2Enabled, Button3Disabled]
            //  if level after current is not cleared then disable the button
            //  (enable buttons up to and including the first false)

            //Debug.Log("level select, cleared level: " + i + " status " + MainManager.Instance.clearedLevels[i-1]);
            if (!MainManager.Instance.clearedLevels[i-1])
                button.gameObject.GetComponent<Button>().interactable = false;
            i++;
        }
        
    }
}