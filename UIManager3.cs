using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UIManager3 : MonoBehaviour
{

    GameObject[] GameOver1Objects;
    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
        GameOver1Objects = GameObject.FindGameObjectsWithTag("ShowOnGameOver");
        hideGameOver1Objects();
    }

    // Update is called once per frame
    void Update()
    {

       
        
            //uses the p button to pause and unpause the game
            if (Input.GetKeyDown(KeyCode.P))
            {
                hideGameOver1Objects();
            }
            else if ( Time.timeScale == 0)
        {
            showGameOver1Objects();
        }
        
    }



    //Reloads the Level
    public void Reload()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    //controls the pausing of the scene
    //shows objects with ShowOnPause tag
    public void showGameOver1Objects()
    {
        foreach (GameObject g in GameOver1Objects)
        {
            g.SetActive(true);
        }
    }

    //hides objects with ShowOnPause tag
    public void hideGameOver1Objects()
    {
        foreach (GameObject g in GameOver1Objects)
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
