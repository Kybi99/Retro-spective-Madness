using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    void OnLevelWasLoaded(int level)
    {
        if (FindObjectOfType<PlayerMovement>() != null)
        {
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    public LevelLoader levelLoader;
    public void PlayGame()
    {
        levelLoader.LoadNextLevel();
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
