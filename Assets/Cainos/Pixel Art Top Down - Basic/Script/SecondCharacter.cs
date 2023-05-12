using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class SecondCharacter : MonoBehaviour
{
    public float speed;

    private Animator animator;

    Vector2 dir = Vector2.zero;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    private void Update()
    {

        // if (Input.GetKey(KeyCode.LeftArrow))
        // {
        //     dir.x = -1;
        //     animator.SetInteger("Direction", 3);
        // }
        // else if (Input.GetKey(KeyCode.RightArrow))
        // {
        //     dir.x = 1;
        //     animator.SetInteger("Direction", 2);
        // }

        // if (Input.GetKey(KeyCode.UpArrow))
        // {
        //     dir.y = 1;
        //     animator.SetInteger("Direction", 1);
        // }
        // else if (Input.GetKey(KeyCode.DownArrow))
        // {
        //     dir.y = -1;
        //     animator.SetInteger("Direction", 0);
        // }

        dir.Normalize();
        animator.SetBool("IsMoving", dir.magnitude > 0);

        GetComponent<Rigidbody2D>().velocity = speed * dir;
    }
    public void OnMove(InputValue val)
    {
        dir = val.Get<Vector2>();
    }
}