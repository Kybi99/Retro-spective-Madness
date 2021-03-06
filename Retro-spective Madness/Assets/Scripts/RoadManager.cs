using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoadManager : MonoBehaviour
{
    public GameObject[] segments;
    public float speed = .1f;
    float segmentSize = 10f;

    float startTime = 0f;
    float holdTime = 5f;

    private void Update()
    {
        MoveSegments();
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("PortalScene");
    }

    private void MoveSegments()
    {
       
        if (Input.GetKey(KeyCode.R))
        {
            Invoke("ChangeScene", 2.0f);
            

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
