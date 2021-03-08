using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

   // public static PlayerState playerState;
    public static LevelState levelState;
    public PlayerMovement playerMovement;
    public LookAround lookAround;
    
    /*public enum PlayerState
    {
        idle,
        running,
        dead
    }*/

    public enum LevelState
    {
        solved,
        failed,
        rewinding
    }
    private void Start()
    {
        levelState = LevelState.failed;
    }

    public void Update()
    {
        if (levelState == LevelState.rewinding)
        {
            playerMovement.enabled = false;
            lookAround.enabled = false;
        }
    }

   /* public void LevelSolved() 
    {
        levelState = LevelState.solved; 
    }
    public void LevelFailed()
    {
        levelState = LevelState.failed;
    }
    
    public void LevelRewinding()
    {
        levelState = LevelState.rewinding;
    }*/
}
