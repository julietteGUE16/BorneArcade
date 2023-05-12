using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class menuController : MonoBehaviour 
{
    Joystick j2=null;
    ButtonHoverDetector buttonHoverDetector;
    ControllerKeyboard myKeyboard;
    GameObject lastHighlightedButton;
    getData getData;
    MyButton myButton;
    // Start is called before the first frame update
    void Start()
    {
        getData = FindObjectOfType<getData>();
        myButton = FindObjectOfType<MyButton>();
         var devices = InputSystem.devices;
         //j2 = devices[1] as Joystick;
         //Debug.Log("j2 : "+j2.name);
         buttonHoverDetector = FindObjectOfType<ButtonHoverDetector>();
            myKeyboard =    FindObjectOfType<ControllerKeyboard>();
            
        
    }

    // Update is called once per frame
    void Update()
    {
     /*if(j2 != null){
       
      if(j2.trigger.ReadValue() == 1){
                //Debug.Log("j2 : " + j2.trigger.ReadValue());
                
           
                if (buttonHoverDetector != null)
                {
                    
                    // Utilisez ici la fonction pour réagir au bouton en surbrillance
                    Debug.Log("buttonHoverDetector : " +    buttonHoverDetector.getButtonName());
                    buttonHoverDetector.OnPointerEnter(null);
                    //myKeyboard.setletter(buttonHoverDetector.getButtonName());
                }
            }else {


            }
     }*/
        
    }

    public void goBack(string sceneName)
    {

         if(getData.isPlayer2){
                getData.isPlayer2 = false;
                getData.namePlayer.text = getData.playerNames[0];
                getData.playerNameText.text = "Player 1";
                getData.PlayerNameTextPanel.text = "Player 1";

               
            }else {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
            }
    }

    public void loadAllScene(string sceneName)
    {
       
        
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        
        //yield return new WaitForSeconds(0.5f);
    }

    public void Quit ()
    {
        if(Application.isEditor){
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else{
        Application.Quit();
        }
    }

    


}
