using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeRewind : MonoBehaviour
{
    [HideInInspector] static public bool isRewinding = false;
    public float recordTime = 5f;
    public GameObject player;
    List<PointInTime> pointsInTime;
    public LevelLoader levelLoader;
    void Start()
    {
        pointsInTime = new List<PointInTime>();
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Trigger")
        {
            StartRewind();
            Invoke("StopRewind", 3);
            Invoke("LoadNextScene", 3);
            DialogManager.canTalk = true;
        }
    }

    public void LoadNextScene()
    {
        Debug.Log(GameManager.levelState);
        if (GameManager.levelState == GameManager.LevelState.solved) 
        {
            levelLoader.LoadNextLevel();
            GameManager.levelState = GameManager.LevelState.failed;
        }
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void FixedUpdate()
    {
        if (isRewinding)
            Rewind();

        else
            Record();
    }
    void Rewind()
    {
        if (pointsInTime.Count > 0) 
        {
            PointInTime pointInTime = pointsInTime[0];
            transform.position = pointInTime.position;
            transform.rotation = pointInTime.rotation;
            pointsInTime.RemoveAt(0);
        }
        else
        {
            StopRewind();
        }
    }
    void Record()
    {
        if (pointsInTime.Count > Mathf.Round(recordTime / Time.fixedDeltaTime))
        {
            pointsInTime.RemoveAt(pointsInTime.Count - 1);
        }

        pointsInTime.Insert(0, new PointInTime(transform.position,transform.rotation));
    }
    public void StartRewind()
    {
        isRewinding = true;
    }

    public void StopRewind()
    {
        isRewinding = false;
    }
}
