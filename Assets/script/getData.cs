    using UnityEngine;
    using UnityEngine.UI;
    using TMPro;

    public class getData : MonoBehaviour
    {
        public TextMeshProUGUI namePlayer;
        
        public string[] playerNames = new string[2];
        public bool isPlayer2 = false;
        dataBase dataBase;
        menuController menuController;
       
        public TextMeshProUGUI playerNameText;
        public TextMeshProUGUI sameName;
        

        private void Start()
        {
           
            menuController = GameObject.FindObjectOfType<menuController>();
            // Ajouter un gestionnaire d'événements pour détecter les changements de texte
            dataBase = GameObject.FindObjectOfType<dataBase>();
            namePlayer = GameObject.Find("name").GetComponent<TextMeshProUGUI>();
            sameName = GameObject.Find("sameName").GetComponent<TextMeshProUGUI>();
            sameName.enabled = false;


            if (namePlayer != null)
            {
                namePlayer.text = "";
            }
           
            
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
                if(!isPlayer2){
                    playerNames[0] = namePlayer.text;
                    namePlayer.text = "";
                    playerNameText.text = "Player 2";
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

                }
                

                
            }
            
            
           
            // Récupérer le texte entré lorsque l'utilisateur appuie sur un bouton de soumission
            //inputText  = namePlayer.text;
            //dataBase.AddScore(inputText, 1);
           
            //Debug.Log("Texte soumis : " + inputText);
        }
    }