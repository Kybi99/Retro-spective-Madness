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
    public GameManager gameManager;

    private void Start()
    {
        timerIsRunning = true;
    }

    void Update()
    {
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
                gameManager.LevelFailed();
            }
        }
    }
}