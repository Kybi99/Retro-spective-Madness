using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Animator animator;
    public float forwardMoveSpeed = 6f;
    public float sideMoveSpeed = 6f;
    public float backwardMoveSpeed = 3f;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        Move();
        
    }

    private void Move()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var movement = new Vector3(horizontal, 0, vertical);

        if (Input.GetKeyDown(KeyCode.D) && !Input.GetKeyDown(KeyCode.W) && !Input.GetKeyDown(KeyCode.S) && !Input.GetKeyDown(KeyCode.A))
            animator.SetBool("RunningRight", true);
        else if (Input.GetKeyDown(KeyCode.A) && !Input.GetKeyDown(KeyCode.W) && !Input.GetKeyDown(KeyCode.S) && !Input.GetKeyDown(KeyCode.D))
            animator.SetBool("RunningLeft", true);
        else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("RunningRight", false);
            animator.SetBool("RunningLeft", false);
        }

        animator.SetFloat("Speed", vertical);


        if (vertical != 0)
        {
            float moveSpeedToUse = (vertical > 0) ? forwardMoveSpeed : backwardMoveSpeed;
            controller.SimpleMove(transform.forward * moveSpeedToUse * vertical);
        }
        if (horizontal != 0)
        {
            float moveSpeedToUse;
            moveSpeedToUse = (vertical >= 0) ? sideMoveSpeed : sideMoveSpeed / 2;
            controller.SimpleMove(transform.right * moveSpeedToUse * horizontal);
        }


    }
}


