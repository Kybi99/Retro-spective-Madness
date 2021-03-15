using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused;
    public GameObject pausemenuUi;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {  
            if (gameIsPaused)
                Resume();
            else
                Pause();
        }
    }
    public void Resume()
    {
        pausemenuUi.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Pause()
    {
        pausemenuUi.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true; 
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
