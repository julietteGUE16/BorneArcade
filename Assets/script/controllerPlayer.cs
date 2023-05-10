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
    Joystick Jj4;
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        rb =GetComponent<Rigidbody2D>();
        Time.timeScale = 0.25f;
        var devices = InputSystem.devices;
        menuStart = FindObjectOfType<menuStart>();
        Debug.Log(" menuStart voir jj4 :  "+menuStart.Jj4);
        //Jj4= menuStart.Jj4;
        Jj4 = devices[0] as Joystick;
        sprite = GetComponent<SpriteRenderer>();
        //Debug.Log(" device 4 :  "+devices[0].name);
        //Debug.Log(" device 5 :  "+devices[1].name);
      

      
             
    }
    // Update is called once per frame

 

    void Update()
    {



        
       
          
         // Lire la valeur du stick analogique gauche en tant que Vector2
         //pour le gamepad
        //Debug.Log("j2 : "+j2.leftStick.ReadValue());
        if(menuStart != null && menuStart.Jj4 != null){
            if(Jj4.trigger.ReadValue() == 1){
            sprite.color = Color.blue;
        }else{
            sprite.color = Color.white;
        }


        
        Debug.Log(" Trigger "+Jj4.trigger.ReadValue());
        Debug.Log(" twist  "+Jj4.twist.ReadValue());
        //Debug.Log(" hatswitch  "+Jj4.hatswitch.ReadValue());
        Vector2 stickPosition = Jj4.stick.ReadValue();
    
        rb.velocity = stickPosition * speed;
            //Debug.Log("Jj4 : "+menuStart.Jj4.stick.ReadValue());
        }else {
            //Debug.Log("Jj4 null");
        }


       

      
        
    }

     
    
     
}


