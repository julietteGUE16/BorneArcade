using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class menuStart : MonoBehaviour
{
   
    

    private Gamepad j1=null;
    private Gamepad j2=null;
    private Joystick Jj1=null;
    private Joystick Jj2=null;
    public Joystick Jj3=null;
    public Joystick Jj4=null;




 
   
    // Start is called before the first frame update
    void Start()
    {
       


        var devices = InputSystem.devices;

       

           for (int i = 0; i < devices.Count; i++)
             {
                 Debug.Log(" device "+i+" :  "+devices[i].name);
             }

      // Jj1 = devices[0] as Joystick;
        // Jj2 = devices[1] as Joystick;
          Jj3 = devices[2] as Joystick;
           Jj4 = devices[3] as Joystick;

        //Debug.Log(" device 4 :  "+devices[0].name);
        //Debug.Log(" device 5 :  "+devices[1].name);
        // if(devices.Count>1){
        //     Debug.Log(" devices :  "+devices.Count);
        //     for (int i = 0; i < devices.Count; i++)
        //     {
        //         Debug.Log(" device :  "+devices[i].name);
        //         if(devices[i].name == "XInputControllerWindows"){
        //             //Debug.Log("XInputControllerWindows");
        //             if(i == 0){
        //             j1 = devices[i] as Gamepad;
        //             }else if(i == 1){
        //             j2 = devices[i] as Gamepad;
        //             }
        //         }else if(devices[i].name == "DragonRise Inc.   Generic   USB  Joystick  "){
                    
        //              if(i == 0){
        //             Jj1  = devices[i] as Joystick;
        //             }else if(i == 1){
        //             Jj2 = devices[i] as Joystick;
        //             }
        //     }
            //Debug.Log(" device player 1 :  "+devices[0].name);
            //Debug.Log(" device player 2 :  "+devices[1].name);
          
           
            }

            // Debug.Log("J1 : "+j1);
            // Debug.Log("J2 : "+j2);
            // Debug.Log("Jj1 : "+Jj1);
            // Debug.Log("Jj2 : "+Jj2);

            
            

            
       
        
       

      
             
    

    
    void Update()
    {
        //gamePad
        //Debug.Log("J1 : "+j1.leftStick.ReadValue());
        //Joystick
        if(Jj2 != null){
        //Debug.Log("Jj2 : "+Jj2.stick.ReadValue());  
        }

        if(Jj3 != null){
        //Debug.Log("Jj3 : "+Jj3.stick.ReadValue());  
        }

        if(Jj2 != null){
        //Debug.Log("Jj4 : "+Jj4.stick.ReadValue());  
        }

        //Debug.Log("Jj2 : " + Jj2.buttonSouth.ReadValue());; 
}
}
