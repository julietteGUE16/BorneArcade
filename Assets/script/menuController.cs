using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class menuController : MonoBehaviour 
{
    
    ButtonHoverDetector buttonHoverDetector;
    ControllerKeyboard myKeyboard;
    GameObject lastHighlightedButton;
    getData getData;
    MyButton myButton;
    PanelOpener PanelOpener;
    ControlCurseur controlCurseur;
    
    // Start is called before the first frame update
    void Start()
    {
        getData = FindObjectOfType<getData>();
        myButton = FindObjectOfType<MyButton>();
        buttonHoverDetector = FindObjectOfType<ButtonHoverDetector>();
        myKeyboard = FindObjectOfType<ControllerKeyboard>();
        PanelOpener = FindObjectOfType<PanelOpener>();
        controlCurseur = FindObjectOfType<ControlCurseur>();
            
        
    }

    // Update is called once per frame
    void Update()
    {
    
        
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
        
       
    }

    public void Quit ()
    {
        
        Application.Quit();
        
    }

    public void CloseThePanel(){
        PanelOpener.ClosePanel();
        controlCurseur.panelOpen = false;
        getData.eventSystem.SetSelectedGameObject(getData.menuControl);

    }

    


}
