using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string firstLevel;

    public GameObject optionsScreen;

    public GameObject titleScreen;

    public string nextLevel;

    public GameObject pauseMenuUI;

    public static bool IsGamePaused = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
            //PauseGame();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(firstLevel);
    }

    public void OpenOptions()
    {
        optionsScreen.SetActive(true);
        titleScreen.SetActive(false);
    }

    public void CloseOptions()
    {
        optionsScreen.SetActive(false);
        titleScreen.SetActive(true);

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsGamePaused = false;
    }
    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        IsGamePaused = true;
    }

    public void GoToLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }

   
}
