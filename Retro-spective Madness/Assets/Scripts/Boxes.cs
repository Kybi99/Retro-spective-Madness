using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxes : MonoBehaviour
{
    private List<Collider> collidedObjects = new List<Collider>();
    bool uFailed = false;

    private void OnControllerColliderHit(ControllerColliderHit other)
    {
        if (!collidedObjects.Contains(other.collider) && other.collider.tag == "Target")
            collidedObjects.Add(other.collider);

        if (other.collider.tag == "WrongBox")
        {
            uFailed = true;
            GameManager.levelState = GameManager.LevelState.failed;
        }


    }
    private void Update()
    {
        if (collidedObjects.Count == 11 && !uFailed)
            GameManager.levelState = GameManager.LevelState.solved;
    }
}