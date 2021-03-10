using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [HideInInspector] public float timeRemaining = 5;
    public bool timerIsRunning = false;
    public Text time;
    private float timeLeft;
    public Gun gun;

    private void Start()
    {
        Invoke("StartTimer", 2);
    }

    void Update()
    {
        if (gun.i == 3 && timeRemaining > 0)
        {
            GameManager.levelState = GameManager.LevelState.solved;
        }

        if (Input.GetKey(KeyCode.T))
        {
            timerIsRunning = false;
        }
        if (timerIsRunning)
        {   
            if (timeRemaining > 0)
            {
                timeLeft = Mathf.Round(timeRemaining);
                time.text ="Time Remaining: " + timeLeft.ToString();
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                GameManager.levelState = GameManager.LevelState.failed;
                time.text = "Time Elapsed ";
            }
        }
    }
    void StartTimer()
    {
        timerIsRunning = true;
    }
}