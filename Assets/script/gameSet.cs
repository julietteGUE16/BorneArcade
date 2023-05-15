using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


/*
Ce script permet de stocker les informations de la partie en cours
*/


public class GameSet : MonoBehaviour
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

    public int rankGame=0;

    bool canClick = true;
    public Joystick j2=null;
    public Gamepad g2=null;
    public Joystick j1=null;
    public Gamepad g1=null;

    public bool firstManetteFound = false;

    EventSystem eventSystem;

    

    public int playerNumber;
 
   
    private void Awake()
    {
        
        DontDestroyOnLoad(gameObject);
    }
        
    void Start()
    {
        eventSystem = EventSystem.current;
        var devices = InputSystem.devices;

        for(int i=0;i<devices.Count;i++){          

            if(devices[i].name.Contains("XInputControllerWindows") || devices[i].name.Contains("XInputControllerWindows1")){
                if(firstManetteFound == false){
                    firstManetteFound = true;
                    g1 = devices[i] as Gamepad;
                }else {
                    g2 = devices[i] as Gamepad;
                }
            
            }else  if(devices[i].name.Contains("DragonRise Inc.   Generic   USB  Joystick")) {
                if(firstManetteFound == false){
                    firstManetteFound = true;
                    j1 = devices[i] as Joystick;
                }else {
                    j2 = devices[i] as Joystick;
                }
            }

        }

       
        
    }

    // Update is called once per frame
    void Update()
    {

        eventSystem = EventSystem.current;
          if(j1 != null){
            if(j1.trigger.value == 1){
                if(canClick){
                    if(SceneManager.GetActiveScene().name != "game1"){
                        canClick = false;
                        StartCoroutine(waitForClick());
                        eventSystem.currentSelectedGameObject.GetComponent<Button>().onClick.Invoke();
                    }
                }
            }
        }
        
        
    }

    public IEnumerator waitForClick(){
        yield return new WaitForSeconds(1f);
        canClick = true;
    }
}
