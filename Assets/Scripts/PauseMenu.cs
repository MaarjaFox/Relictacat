using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour

    
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject optionsScreen;
    public GameObject tutorialScreen;

 // Update is called once per frame
    public void OpenPanel()
    {
         if(pauseMenuUI != null)
        {
            if (GameIsPaused)
            {
                bool isActive = pauseMenuUI.activeSelf;

                pauseMenuUI.SetActive(!isActive); 
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
   

    public void Resume ()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause ()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()

    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void LoadGame()

    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Intro scene");
    }

    public void OpenOptions()
    {
        optionsScreen.SetActive(true);
    }

    public void CloseOptions()
    {
        optionsScreen.SetActive(false);
    }


    public void OpenTutorial()
    {
        tutorialScreen.SetActive(true);
    }

    public void CloseTutorial()
    {
        tutorialScreen.SetActive(false);
    }

    public void QuitGame() //Do I really need to implement this to a mobile game? Never have I used quit option to quit mobile game lol
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
