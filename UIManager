using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class UIManager : MonoBehaviour
{
    GameObject[] pauseObjects;
    GameObject[] finishObjects;
    GameObject[] gameOverObjects;
   
   


    ThirdPersonUserControl playerController;
    public bool alive;
    public int thiscount;
    private object playerScript;

    //private object playerScript;

    // Use this for initialization
    void Start()
    {
        //GameObject player = GameObject.Find("Player");
       //ThirdPersonUserControl playerScript = player.GetComponent<ThirdPersonUserControl>();
        //thiscount = count;
        alive = false;
        Time.timeScale = 1;

        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");            //gets all objects with tag ShowOnPause
        finishObjects = GameObject.FindGameObjectsWithTag("ShowOnFinish");          //gets all objects with tag ShowOnFinish
        gameOverObjects = GameObject.FindGameObjectsWithTag("ShowOnGameOver");
        
        hidePaused();
        hideFinished();
        hideGameOver();
        
        //Checks to make sure MainLevel is the loaded level

    }

    // Update is called once per frame
    void Update()
    {
        //thiscount = playerScript.count;
        //uses the p button to pause and unpause the game
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                showPaused();
            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                hidePaused();
            }
        }
        //uses the p button to pause and unpause the game
        

        //shows finish gameobjects if player is dead and timescale = 0
        else if (Time.timeScale == 0 && ThirdPersonUserControl.count == 100 )
        {
            //Debug.Log("working");
            showFinished();
        }
        else if (Time.timeScale == 0 && ThirdPersonUserControl.fake == 1)
        {
            //Debug.Log("working");
            showGameOver();
        }

    }


    //Reloads the Level
    public void Reload()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    //controls the pausing of the scene
    public void pauseControl()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            showPaused();
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            hidePaused();
        }
    }

    //shows objects with ShowOnPause tag
    public void showPaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
    }

    //hides objects with ShowOnPause tag
    public void hidePaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
    }

    //shows objects with ShowOnFinish tag
    public void showFinished()
    {
        foreach (GameObject g in finishObjects)
        {
            g.SetActive(true);
        }
    }

    //hides objects with ShowOnFinish tag
    public void hideFinished()
    {
        foreach (GameObject g in finishObjects)
        {
            g.SetActive(false);
        }
    }
    public void showGameOver()
    {
        foreach (GameObject g in gameOverObjects)
        {
            g.SetActive(true);
        }
    }

    //hides objects with ShowOnFinish tag
    public void hideGameOver()
    {
        foreach (GameObject g in gameOverObjects)
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