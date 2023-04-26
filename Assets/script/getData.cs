    using UnityEngine;
    using UnityEngine.UI;
    using TMPro;

    public class getData : MonoBehaviour
    {
       public TextMeshProUGUI namePlayer;
        public Button button;
        dataBase dataBase;
          string inputText;

        private void Start()
        {
            // Ajouter un gestionnaire d'événements pour détecter les changements de texte
            dataBase = GameObject.FindObjectOfType<dataBase>();
            namePlayer = GameObject.Find("name").GetComponent<TextMeshProUGUI>();
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
               
            // Récupérer le texte entré lorsque l'utilisateur appuie sur un bouton de soumission
            inputText  = namePlayer.text;
            dataBase.AddScore(inputText, 1);
           
            Debug.Log("Texte soumis : " + inputText);
        }
    }