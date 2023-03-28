    using UnityEngine;
    using UnityEngine.UI;
    using TMPro;

    public class getData : MonoBehaviour
    {
        public TMP_InputField inputField;
        public Button button;

        private void Start()
        {
            // Ajouter un gestionnaire d'événements pour détecter les changements de texte
           
            
        }

        private void Update (){
              inputField.onValueChanged.AddListener(OnInputFieldValueChanged);
             button.onClick.AddListener(delegate { SubmitInput(); });
            
           // button.onClick.AddListener(delegate { OnInputFieldValueChanged(inputField.text); });

        }

        private void OnInputFieldValueChanged(string value)
        {
            Debug.Log("Nouvelle valeur de texte : " + value);
        }

        public void SubmitInput()
        {
            // Récupérer le texte entré lorsque l'utilisateur appuie sur un bouton de soumission
            string inputText = inputField.text;
            Debug.Log("Texte soumis : " + inputText);
        }
    }