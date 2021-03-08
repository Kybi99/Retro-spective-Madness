using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static PlayerState playerState;
    public static LevelState levelState;

    public enum PlayerState
    {
        idle,
        running,
        dead
    }

    public enum LevelState
    {
        solved,
        failed
    }

    public void LevelSolved() 
    {
        levelState = LevelState.solved; 
    }
    public void LevelFailed()
    {
        levelState = LevelState.failed;
    }
    
}
