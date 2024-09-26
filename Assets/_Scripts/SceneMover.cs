using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMover : MonoBehaviour
{
    public int transitiontime = 1;
    public bool atranstition = false;

    public int scenetomove = 2;
    
    public void MoveScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
    public void Transition()
    {
        SceneManager.LoadScene(scenetomove);
    }
    public void Quit()
    {
        Application.Quit();
    }
    private void Awake()
    {
        if (atranstition == true)
        {
            Invoke("Transition", transitiontime);
        }
    }
}
