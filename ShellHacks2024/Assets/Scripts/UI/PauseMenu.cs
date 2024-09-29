using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] public GameObject pauseMenu;
    private InputManager inputManager;

    void Awake()
    {
        inputManager = FindObjectOfType<InputManager>();
        inputManager.OnPause.AddListener(ShowPauseMenu);
    }
   

    private void ShowPauseMenu()
    {
        Debug.Log("Pause");
        
        if (!pauseMenu.activeSelf)
        {
            Time.timeScale = 0f; // Pauses the game
            pauseMenu.SetActive(true); // Displays the pause menu
            // Shows the cursor
        }
        // Otherwise, resume the game and hide the menu
        else
        {
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
           
        }

    }

    // Quits the game
    public void quit()
    {
        Application.Quit();
    }

    // Resumes the game when called
    public void resume()
    {
        Debug.Log("Resume");
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        
    }

    // Loads the main menu scene (index 0)
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

}

