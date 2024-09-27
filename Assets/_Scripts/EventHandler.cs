using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.SceneManagement;

public class EventHandler : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused = false;

    // Score Method, also keep track of the scoring.

    private void Start()
    {
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            OnPause(isPaused);
        }
    }

    public void WinorLose()
    {
        /*
        if (player dies) {
        SceneManager.LoadScene(//WinScene)
        // Pull data from stats
        }
        if (player wins) {
        SceneManager.LoadScene(//WinScene)
        // Pull data from stats
        }
        */
    }

    public void GoToMainMenu()
    {
        if (!isPaused)
        {
            //SceneManager.LoadScene(MainMenu)
        }
    }

    private void OnPause(bool p)
    {
        if (!p) 
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            isPaused = true;
        }
        else
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            isPaused = false;
        }
    }
}
