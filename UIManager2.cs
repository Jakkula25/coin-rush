using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UIManager2 : MonoBehaviour
{
    
    GameObject[] GameOverObjects;
    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
        GameOverObjects = GameObject.FindGameObjectsWithTag("ShowOnWin");
        hideGameOverObjects();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            hideGameOverObjects();
        }
        else if (Time.timeScale == 0)
        {
            showGameOverObjects();
        }
    }



                /* if (Time.timeScale == 1)
                 {
                     Time.timeScale = 0;
                     showGameOverObjects();
                 }*/
               
   
    //Reloads the Level
    public void Reload()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    //controls the pausing of the scene
    //shows objects with ShowOnPause tag
    public void showGameOverObjects()
    {
        foreach (GameObject g in GameOverObjects)
        {
            g.SetActive(true);
        }
    }

    //hides objects with ShowOnPause tag
    public void hideGameOverObjects()
    {
        foreach (GameObject g in GameOverObjects)
        {
            g.SetActive(false);
        }
    }

    //loads inputted level
    public void LoadLevel(string level)
    {
        Application.LoadLevel(level);

    }
    public void toQuit()
    {
        Application.Quit();
    }
    public void LoadAgain(string level)
    {
        Application.LoadLevel(level);

    }
}