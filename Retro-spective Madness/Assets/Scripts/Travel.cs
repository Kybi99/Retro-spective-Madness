using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Travel : MonoBehaviour
{
    public Transform player;
    public Transform destination;
    private void OnTriggerEnter(Collider other)
    {
        player.transform.position = destination.transform.position;
    }


  
}
