    using UnityEngine;
    using UnityEngine.UI;
    using TMPro;

    public class getData : MonoBehaviour
    {
        public TMP_InputField inputField;
        public Button button;
        dataBase dataBase;
          string inputText;

        private void Start()
        {
            // Ajouter un gestionnaire d'événements pour détecter les changements de texte
            dataBase = GameObject.FindObjectOfType<dataBase>();
            inputField = FindObjectOfType<TMP_InputField>();
            if (inputField != null)
            {
                inputField.text = "";
            }
           
            
        }

        private void Update (){

        /*if(inputField.text.Length > 0){
            
           Debug.Log("Soumettre le texte entré : "+inputField.text);
        } else {
            Debug.Log("Veuillez rentrer un nom");
        }*/
        }

        public void setletter(string letter){
            inputField.text = inputField.text + letter;
        }

        

        public void SubmitInput()
        {
               
            // Récupérer le texte entré lorsque l'utilisateur appuie sur un bouton de soumission
            inputText  = inputField.text;
            dataBase.AddScore(inputText, 1);
           
            Debug.Log("Texte soumis : " + inputText);
        }
    }