using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;




public class controllerPlayer : MonoBehaviour
{
    
    private Rigidbody2D rb;
    public float speed=10f;
    menuStart menuStart;
    Joystick j1=null;
    Gamepad g1=null;
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        rb =GetComponent<Rigidbody2D>();
        Time.timeScale = 0.25f;
        var devices = InputSystem.devices;
        menuStart = FindObjectOfType<menuStart>();
        sprite = GetComponent<SpriteRenderer>();
       
          if(devices.Count>0){
       if(devices[0].name.Contains("XInputControllerWindows")){
           g1 = devices[0] as Gamepad;
           Debug.Log("g1 : "+g1.name);
       }else {
           j1 = devices[0] as Joystick;
       }
          }
       
    
 
      

      
             
    }
    // Update is called once per frame

 

    void Update()
    {



        
       
          
         // Lire la valeur du stick analogique gauche en tant que Vector2
         //pour le gamepad
        //Debug.Log("j2 : "+j2.leftStick.ReadValue());
        if(j1 != null){
            if(j1.trigger.ReadValue() == 1){
            sprite.color = Color.blue;
        }else{
            sprite.color = Color.white;
        }


        Vector2 stickPosition = j1.stick.ReadValue();
    
        rb.velocity = stickPosition * speed;
            
        }else if(g1 != null){
            if(g1.leftTrigger.ReadValue() == 1){
            sprite.color = Color.blue;
        }
        else{
            sprite.color = Color.white;
        }
        Vector2 stickPosition = g1.leftStick.ReadValue();

        rb.velocity = stickPosition * speed;
        }
        
        else {
         Debug.Log("j1 et g1 null");
        }


       

      
        
    }

     
    
     
}


