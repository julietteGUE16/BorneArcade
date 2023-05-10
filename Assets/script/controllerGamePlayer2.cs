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
    Joystick j2;
    Gamepad g2;
    // Start is called before the first frame update
    void Start()
    {
        rb =GetComponent<Rigidbody2D>();
        Time.timeScale = 0.25f;
        var devices = InputSystem.devices;
        menuStart = FindObjectOfType<menuStart>();
        Debug.Log(" device 1 :  "+devices[1].name);
        Debug.Log("test = "+devices[1].name.Contains("XInputControllerWindows"));
        if(devices.Count>1){
          if(devices[1].name.Contains("XInputControllerWindows")){
           g2 = devices[1] as Gamepad;
           Debug.Log("g1 : "+g2.name);
        }else {
            j2 = devices[1] as Joystick;
        }
        }

        //Debug.Log(" device 4 :  "+devices[0].name);
        //Debug.Log(" device 5 :  "+devices[1].name);
      

      
             
    }
    // Update is called once per frame

 

    void Update()
    {



        

          if(j2 != null){
          


        Vector2 stickPosition = j2.stick.ReadValue();
    
        rb.velocity = stickPosition * speed;
            
        }else if(g2 != null){
           
        Vector2 stickPosition = g2.leftStick.ReadValue();

        rb.velocity = stickPosition * speed;
        }
        
        else {
         Debug.Log("j2 et g2 null");
        }
      
        

       

      
        
    }

     
    
     
}

