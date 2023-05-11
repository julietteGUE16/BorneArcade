using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using TMPro;





public class Player : MonoBehaviour
{
    
   
   

    private Rigidbody2D rb;
    public float speed=10f;
    public int playerNumber;
    public string playerName;
    public TextMeshProUGUI playerNameText;

    Joystick j2;
    Gamepad g2;
    // Start is called before the first frame update
    void Start()
    {
        rb =GetComponent<Rigidbody2D>();
        Time.timeScale = 0.25f;
        var devices = InputSystem.devices;
      
        Debug.Log(" device 1 :  "+devices[playerNumber].name);
        Debug.Log("test = "+devices[playerNumber].name.Contains("XInputControllerWindows"));
        if(devices.Count>1){
          if(devices[playerNumber].name.Contains("XInputControllerWindows")){
           g2 = devices[playerNumber] as Gamepad;
           Debug.Log("g1 : "+g2.name);
        }else {
            j2 = devices[playerNumber] as Joystick;
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


