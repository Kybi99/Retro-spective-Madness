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
    public void PlayLevel1()
    {
        levelLoader.LoadLevel1();
    }
    public void PlayLevel2()
    {
        levelLoader.LoadLevel2();
    }
    public void PlayLevel3()
    {
        levelLoader.LoadLevel3();
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
