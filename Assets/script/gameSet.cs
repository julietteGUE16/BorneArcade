using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class gameSet : MonoBehaviour
{
    
    

    
    public int idPartie=-1;
    public int scorePlayer1=0;
    public int scorePlayer2=0;

    public int idPlayer1=-1;
    public int idPlayer2=-1;
    public string namePlayer1="";
    public string namePlayer2="";
     
    public float speedPlayer1=0.1f;
    public float speedRotationPlayer1=0.2f;
    public float powerFire1=0.2f;
    public float delayFire1=0.2f;
    

    public float speedPlayer2=0.1f;
    public float speedRotationPlayer2=0.2f;
    public float powerFire2=0.2f;
    public float delayFire2=0.2f;

    bool canClick = true;
    Joystick j2=null;
    Gamepad g2=null;
    Joystick j1=null;
    Gamepad g1=null;

    EventSystem eventSystem;

    public int playerNumber;
 
    // Start is called before the first frame update
    private void Awake()
    {
        // Empêcher la destruction de l'objet lors du changement de scène
        DontDestroyOnLoad(gameObject);
    }
        
    void Start()
    {
        eventSystem = EventSystem.current;
         var devices = InputSystem.devices;
      
        //Debug.Log(" device 1 :  "+devices[playerNumber].name);
        //Debug.Log("test = "+devices[playerNumber].name.Contains("XInputControllerWindows"));
        if(devices.Count>1){
          if(devices[0].name.Contains("XInputControllerWindows")){
           g2 = devices[0] as Gamepad;
           
        }else {
            j2 = devices[0] as Joystick;
        }

        
        }

         if(devices.Count>1){
          if(devices[1].name.Contains("XInputControllerWindows")){
           g1 = devices[1] as Gamepad;
           //Debug.Log("g1 : "+g2.name);
        }else {
            j1 = devices[1] as Joystick;
        }
        
        
        }

        Debug.Log("j1 = "+ j1);
        Debug.Log("g1 = "+ g1);
        Debug.Log("j2 = "+ j2);
        Debug.Log("g2 = "+ g2);
        
        
    }

    // Update is called once per frame
    void Update()
    {

        eventSystem = EventSystem.current;
          if(j1 != null){
          


        
            Debug.Log("j2 = "+ j1.trigger.value);
        if(j1.trigger.value == 1){
            if(canClick){
            canClick = false;
            StartCoroutine(waitForClick());


            //playerMouvement
            Debug.Log("tir");
           //Debug.Log("button : "+ eventSystem.currentSelectedGameObject.name);//.onClick.Invoke();
           eventSystem.currentSelectedGameObject.GetComponent<Button>().onClick.Invoke();
            }
        }
           
            
        }else if(g2 != null){
           
         
        
        
        }
        
        else {
         Debug.Log("j2 et g2 null");
        }
        
    }

    public IEnumerator waitForClick(){
        yield return new WaitForSeconds(1f);
        canClick = true;
    }
}