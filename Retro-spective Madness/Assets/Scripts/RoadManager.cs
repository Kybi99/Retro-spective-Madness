using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoadManager : MonoBehaviour
{
    public GameObject[] segments;
    public float speed = .1f;
    float segmentSize = 10f;
    private bool timeGoes=false;
    private float holdTime = 2f;

    private void Update()
    {
        MoveSegments();
        ButtonHold();
    }

    private void ButtonHold()
    {
        if (Input.GetKeyDown(KeyCode.R))
            timeGoes = true;
        if (Input.GetKeyUp(KeyCode.R)) { 
            timeGoes = false;
            holdTime = 2f;
        }
        if (timeGoes)
            holdTime -= Time.deltaTime;
        if (holdTime <= 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    private void MoveSegments()
    {
       
        if (Input.GetKey(KeyCode.R))
        {
           
            for (int i = 0; i < segments.Length; i++)
            {
                float z = segments[i].transform.position.z;
                z += speed;
                z = Mathf.Round(z * 10) / 10;

                segments[i].transform.position = new Vector3(0, 0, z);
                if (segments[i].transform.position.z >= segmentSize * (segments.Length - 1))
                {
                    segments[i].transform.position = new Vector3(0, 0,  -segmentSize);
                }
            }
        }
        else
        {
            for (int i = 0; i < segments.Length; i++)
            {
                float z = segments[i].transform.position.z;
                z -= speed;
                z = Mathf.Round(z * 10) / 10;

                segments[i].transform.position = new Vector3(0, 0, z);
                if (segments[i].transform.position.z <= -segmentSize)
                {
                    segments[i].transform.position = new Vector3(0, 0, (segments.Length - 1) * segmentSize);
                }
            }
        }
    }
}
