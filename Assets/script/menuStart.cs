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
        Debug.Log(" devices :  "+devices.Count);
        if(devices.Count>0){
         // Jj3 = devices[0] as Joystick;
         Jj4 = devices[0] as Joystick;
            Debug.Log("Jj4 : "+Jj4.name);
          if(devices.Count>1){
           
          }

        }
         
         

        
          
           
            }

     

    
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
        if(Jj4 != null){
        //Debug.Log("Jj4 : "+Jj4.stick.ReadValue());  
        }

        //Debug.Log("Jj2 : " + Jj2.buttonSouth.ReadValue());; 
}
}
