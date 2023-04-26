using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;




public class controllerGamePlayer2 : MonoBehaviour
{
    
   
   

    private Rigidbody2D rb;
    public float speed=10f;
    menuStart menuStart;
    Joystick Jj3;
    // Start is called before the first frame update
    void Start()
    {
        rb =GetComponent<Rigidbody2D>();
        Time.timeScale = 0.25f;
        var devices = InputSystem.devices;
        menuStart = FindObjectOfType<menuStart>();
        Jj3= menuStart.Jj3;
        //Debug.Log(" device 4 :  "+devices[0].name);
        //Debug.Log(" device 5 :  "+devices[1].name);
      

      
             
    }
    // Update is called once per frame

 

    void Update()
    {



        

          
         // Lire la valeur du stick analogique gauche en tant que Vector2
         //pour le gamepad
        //Debug.Log("j2 : "+j2.leftStick.ReadValue());
        if(menuStart != null && menuStart.Jj3 != null){
            //Debug.Log("Jj3 : "+menuStart.Jj3.stick.ReadValue());
        }else {
           // Debug.Log("Jj3 null");
        }
        Vector2 stickPosition = Jj3.stick.ReadValue();
    
        rb.velocity = stickPosition * speed;

       

      
        
    }

     
    
     
}


