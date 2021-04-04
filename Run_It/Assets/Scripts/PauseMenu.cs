using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
    private bool isPaused;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // stop the game
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    // Pause Game
    public void PauseGame()
    {
        Time.timeScale = 0;

        // pause the audio
        AudioListener.pause = true;

        // pause UI
        pauseMenuUI.SetActive(!isPaused);

        isPaused = true;
    }

    // Resume Game
    public void ResumeGame()
    {
        Time.timeScale = 1;
        
        // pause the audio
        AudioListener.pause = false;

        // pause UI
        pauseMenuUI.SetActive(!isPaused);

        isPaused = false;   
    }

    // Exit App
    public void ExitApp()
    {
        Application.Quit();
    }

    // Restart Game
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        ResumeGame();
    }

}
