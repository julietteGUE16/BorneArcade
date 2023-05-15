using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

/*
Ce script permet de controler le menu
*/
public class MenuController : MonoBehaviour 
{
    
   
    ControllerKeyboard myKeyboard;
    GameObject lastHighlightedButton;
    GetData getData;
    MyButton myButton;
    PanelOpener PanelOpener;
    ControlCurseur controlCurseur;
    DataBase dataBase;
    
    // Start is called before the first frame update
    void Start()
    {
        getData = FindObjectOfType<GetData>();
        myButton = FindObjectOfType<MyButton>();
        dataBase = FindObjectOfType<DataBase>();
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
            getData.playerNameTextPanel.text = "Player 1";
            dataBase.heExist = true;   

               
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
        controlCurseur.ResetCursor();
        controlCurseur.panelOpen = false;
        getData.eventSystem.SetSelectedGameObject(getData.menuControl);
        controlCurseur.firstTime = true;

    }

    


}
