using UnityEngine;
using UnityEngine.UI;

public class getData : MonoBehaviour
{
    public InputField inputField;

    private void Start()
    {
        // Ajouter un gestionnaire d'événements pour détecter les changements de texte
        inputField.onValueChanged.AddListener(OnInputFieldValueChanged);
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