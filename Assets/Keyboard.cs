using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    using TMPro;


public class Keyboard : MonoBehaviour
{
   
    public TMP_InputField inputField;
    // Start is called before the first frame update
    void Start()
    {
       
    }  

    // Update is called once per frame
    void Update()
    {
       
    }

     public void setletter(string letter){
        if(letter == "DELETE"  && inputField.text.Length > 0){
            inputField.text = inputField.text.Substring(0, inputField.text.Length - 1);
        }else if(letter != "DELETE"){
                if(inputField.text.Length < 10){
                inputField.text =  inputField.text + letter;
            } else{
                Debug.Log("Max 10 caractères");
            }
        }

    }
}
