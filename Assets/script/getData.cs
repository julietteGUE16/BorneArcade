    using UnityEngine;
    using UnityEngine.UI;
    using TMPro;
    using UnityEngine.EventSystems;

    public class getData : MonoBehaviour
    {
        public TextMeshProUGUI namePlayer;
        
        public string[] playerNames = new string[2];
        public bool isPlayer2 = false;
        dataBase dataBase;
        menuController menuController;
       
        public TextMeshProUGUI playerNameText;
        public TextMeshProUGUI PlayerNameTextPanel;
        public TextMeshProUGUI sameName;
        PanelOpener panelOpener;
        EventSystem eventSystem;
        public GameObject panelControl;
        public GameObject menuControl;
        ControlCurseur controlCurseur;
        gameSet gameSet;
        

        private void Start()
        {
           eventSystem = EventSystem.current;
            panelOpener = GameObject.FindObjectOfType<PanelOpener>();
            menuController = GameObject.FindObjectOfType<menuController>();
            gameSet = GameObject.FindObjectOfType<gameSet>();
            // Ajouter un gestionnaire d'événements pour détecter les changements de texte
            dataBase = GameObject.FindObjectOfType<dataBase>();
            namePlayer = GameObject.Find("name").GetComponent<TextMeshProUGUI>();
            sameName = GameObject.Find("sameName").GetComponent<TextMeshProUGUI>();
            sameName.enabled = false;
            controlCurseur = GameObject.FindObjectOfType<ControlCurseur>();


            if (namePlayer != null)
            {
                namePlayer.text = "";
            }
           
            panelOpener.ClosePanel();
            
        }

        private void Update (){

        /*if(namePlayer.text.Length > 0){
            
           Debug.Log("Soumettre le texte entré : "+namePlayer.text);
        } else {
            Debug.Log("Veuillez rentrer un nom");
        }*/
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

                


                //eventSystem.firstSelectedGameObject = panelControl;
                
              
                /*if(!isPlayer2){
                    playerNames[0] = namePlayer.text;
                    namePlayer.text = "";
                    playerNameText.text = "Player 2";
                    PlayerNameTextPanel.text = "Player 2";
                    isPlayer2 = true;
                } else {
                    if(playerNames[0] == namePlayer.text){
                        sameName.enabled = true;
                        
                        
                    } else {
                        playerNames[1] = namePlayer.text;
                    namePlayer.text = "";
                    for(int i = 0; i < playerNames.Length; i++){
                    //Debug.Log("Player "+i+" : "+playerNames[i]);
                    }
                    
                    menuController.loadAllScene("game1");

                    }

                }*/
            }
        }
         public void ValiderPanel(){
            controlCurseur.panelOpen = false;
            eventSystem.SetSelectedGameObject(menuControl);
           panelOpener.ClosePanel();

            if(!isPlayer2){
                dataBase.UpdatePlayer(gameSet.idPlayer1, controlCurseur.cursorSpeedPlayer.GetComponent<Slider>().value, controlCurseur.CursorRotationSpeedPlayer.GetComponent<Slider>().value, controlCurseur.CursorPowerFirePlayer.GetComponent<Slider>().value, controlCurseur.CursorDelayFirePlayer.GetComponent<Slider>().value);
            } else {
                dataBase.UpdatePlayer(gameSet.idPlayer2, controlCurseur.cursorSpeedPlayer.GetComponent<Slider>().value, controlCurseur.CursorRotationSpeedPlayer.GetComponent<Slider>().value, controlCurseur.CursorPowerFirePlayer.GetComponent<Slider>().value, controlCurseur.CursorDelayFirePlayer.GetComponent<Slider>().value);
            }

            controlCurseur.ResetCursor();
            controlCurseur.firstTime = true;

            if(!isPlayer2){
                    playerNames[0] = namePlayer.text;
                    namePlayer.text = "";
                    playerNameText.text = "Player 2";
                    PlayerNameTextPanel.text = "Player 2";
                    isPlayer2 = true;
                } else {
                    
                        playerNames[1] = namePlayer.text;
                    namePlayer.text = "";
                    
                    
                    menuController.loadAllScene("game1");

                    

                }
            



        }
    }