using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;




public class controllerGamePlayer2 : MonoBehaviour
{
    
   
   
    private Gamepad j2;
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
        this.j2 = devices[1] as Gamepad;
       

      
             
    }
    // Update is called once per frame

 

    void Update()
    {



        if (j2 != null){

          
         // Lire la valeur du stick analogique gauche en tant que Vector2
         //pour le gamepad
        Debug.Log("j2 : "+j2.leftStick.ReadValue());
        Vector2 stickPosition = j2.leftStick.ReadValue();
    
        rb.velocity = stickPosition * speed;

        } else {
           // Debug.Log("j1 null");
        }

      
        
    }

     
    
     
}


