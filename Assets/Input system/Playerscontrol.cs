using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Playerscontrol : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;

    void Start()
    {
        rb =GetComponent<Rigidbody2D>();
        Time.timeScale = 0.25f;
        
    }

    
    private void OnMove(InputValue input){
        Vector2 inputVec = input.Get<Vector2>();
        Vector2 vel = rb.velocity;
        Vector2 pos = transform.position;
        rb.velocity = inputVec * speed;
    }
}

