using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static LevelState levelState;
    public PlayerMovement playerMovement;
    public LookAround lookAround;
    public Text solution;


    public enum LevelState
    {
        solved,
        failed
    }

    public void Update()
    {
        if (TimeRewind.isRewinding)
        {
            playerMovement.enabled = false;
            lookAround.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (solution.gameObject.activeInHierarchy)
                solution.gameObject.SetActive(false);
            else
                solution.gameObject.SetActive(true);
        }
    } 
}
