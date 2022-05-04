using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string firstLevel;

    public GameObject optionsScreen;

    public GameObject titleScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
