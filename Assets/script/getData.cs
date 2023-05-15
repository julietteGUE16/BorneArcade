using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;


/*
Ce script permet de récupérer le nom du joueur et de l'envoyer à la base de données
Mais aussi de vérifier si le joueur existe déjà dans la base de données
*/



public class GetData : MonoBehaviour
{
    public TextMeshProUGUI namePlayer;
    public string[] playerNames = new string[2];
    public bool isPlayer2 = false;
    DataBase dataBase;
    MenuController menuController;
    public TextMeshProUGUI playerNameText;
    public TextMeshProUGUI playerNameTextPanel;
    public TextMeshProUGUI sameName;
    PanelOpener panelOpener;
    public EventSystem eventSystem;
    public GameObject panelControl;
    public GameObject menuControl;
    ControlCurseur controlCurseur;
    GameSet gameSet;
    

    private void Start()
    {
        eventSystem = EventSystem.current;
        panelOpener = GameObject.FindObjectOfType<PanelOpener>();
        menuController = GameObject.FindObjectOfType<MenuController>();
        gameSet = GameObject.FindObjectOfType<GameSet>();
        // Ajouter un gestionnaire d'événements pour détecter les changements de texte
        dataBase = GameObject.FindObjectOfType<DataBase>();
        namePlayer = GameObject.Find("name").GetComponent<TextMeshProUGUI>();
        sameName = GameObject.Find("sameName").GetComponent<TextMeshProUGUI>();
        sameName.enabled = false;
        controlCurseur = GameObject.FindObjectOfType<ControlCurseur>();


        if (namePlayer != null)
        {
            namePlayer.text = "";
        }
        
        panelOpener.ClosePanel();
         //eventSystem.SetSelectedGameObject(panelControl);
        
    }

    private void Update (){

    
    }

    

    

    public void SubmitInput()
    {

        
        
        if(namePlayer.text != ""){


            if (isPlayer2 && playerNames[0] == namePlayer.text)
            {
                sameName.enabled = true;
            }
            else
            {
            
            
            dataBase.FindPlayer(namePlayer.text, isPlayer2);
            panelOpener.OpenPanel();
            controlCurseur.panelOpen = true;
            eventSystem.SetSelectedGameObject(panelControl);
        }

            
        }
    }
        public void ValiderPanel(){

            sameName.enabled = false;
            controlCurseur.panelOpen = false;
            eventSystem.SetSelectedGameObject(menuControl);
            panelOpener.ClosePanel();
            if(dataBase.heExist){
                if(!isPlayer2){
                    dataBase.UpdatePlayer(gameSet.idPlayer1, controlCurseur.cursorSpeedPlayer.GetComponent<Slider>().value, controlCurseur.CursorRotationSpeedPlayer.GetComponent<Slider>().value, controlCurseur.CursorPowerFirePlayer.GetComponent<Slider>().value, controlCurseur.CursorDelayFirePlayer.GetComponent<Slider>().value);
                } else {
                    dataBase.UpdatePlayer(gameSet.idPlayer2, controlCurseur.cursorSpeedPlayer.GetComponent<Slider>().value, controlCurseur.CursorRotationSpeedPlayer.GetComponent<Slider>().value, controlCurseur.CursorPowerFirePlayer.GetComponent<Slider>().value, controlCurseur.CursorDelayFirePlayer.GetComponent<Slider>().value);
                }   
            }else {
                dataBase.AddPlayer(namePlayer.text,controlCurseur.cursorSpeedPlayer.GetComponent<Slider>().value, controlCurseur.CursorRotationSpeedPlayer.GetComponent<Slider>().value, controlCurseur.CursorPowerFirePlayer.GetComponent<Slider>().value, controlCurseur.CursorDelayFirePlayer.GetComponent<Slider>().value, isPlayer2);
                    


            }
            dataBase.heExist = true;    

            controlCurseur.ResetCursor();
            controlCurseur.firstTime = true;

            if(!isPlayer2){
                playerNames[0] = namePlayer.text;
                gameSet.namePlayer1 = namePlayer.text;
                namePlayer.text = "";
                playerNameText.text = "Player 2";
                playerNameTextPanel.text = "Player 2";
                isPlayer2 = true;
            } else {
                playerNames[1] = namePlayer.text;
                gameSet.namePlayer2 = namePlayer.text;
                namePlayer.text = "";
                int randomIndex = Random.Range(0, 2);
                if (randomIndex == 0)
                {
                    menuController.loadAllScene("game1");
                }
                else if (randomIndex == 1)
                {
                    menuController.loadAllScene("game2");
                }
             
            }
            



    }
}