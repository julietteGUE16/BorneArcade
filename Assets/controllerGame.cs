using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;




public class controllerGame : MonoBehaviour
{
    
    private Gamepad j1;
    private Joystick j2;

    private Rigidbody2D rb;
    public float speed=10f;
    
    

    // Start is called before the first frame update
    void Start()
    {
        

        rb =GetComponent<Rigidbody2D>();
        Time.timeScale = 0.25f;
        var devices = InputSystem.devices;
      
        Debug.Log(" device 4 :  "+devices[0].name);
        Debug.Log(" device 5 :  "+devices[1].name);

        

        this.j1 = devices[0] as Gamepad;
        this.j2 = devices[1] as Joystick;

        Debug.Log("j1 : "+j1);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (j1 != null){
            //Debug.Log(j1.stick.x);
           // Debug.Log(j1.stick.y);
           
          
          
           // Lire la valeur du stick analogique gauche en tant que Vector2
        Vector2 stickPosition = j1.leftStick.ReadValue();
                Debug.Log("Position du stick analogique gauche : " + stickPosition);

                rb.velocity = stickPosition * speed;

        } else {
           // Debug.Log("j1 null");
        }

        //j2.stick.x.ReadValue();
        
    }

     /*private void OnMove(InputValue input){
          Debug.Log("P2");
          Vector2 inputVec = input.Get<Vector2>();
          Vector2 vel = rb.velocity;
          Vector2 pos = transform.position;
          rb.velocity = inputVec * speed;
     }*/
}
