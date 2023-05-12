using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    using TMPro;


public class ControllerKeyboard : MonoBehaviour
{
   
    public TextMeshProUGUI namePlayer;
    public TextMeshProUGUI setNamePlayerText;
    public TextMeshProUGUI maxCharacters;
    TextMeshProUGUI playerNumber;
   

    // Start is called before the first frame update
    void Start()
    {
        setNamePlayerText.enabled = true;
        namePlayer.enabled = false;
        maxCharacters.enabled = false;
        playerNumber = GameObject.Find("player").GetComponent<TextMeshProUGUI>();
    }  

    // Update is called once per frame
    void Update()
    {
       if(namePlayer.text.Length > 0){
            setNamePlayerText.enabled = false;
            namePlayer.enabled = true;
        } else {
            setNamePlayerText.enabled = true;
            namePlayer.enabled = false;
        }

        if(namePlayer.text.Length < 10){
           maxCharacters.enabled = false;
        } 
        
    }

     public void setletter(string letter){
        if(letter == "Suppr"){
            namePlayer.text = "";
       }else if(letter == "DELETE"  && namePlayer.text.Length > 0){
            namePlayer.text = namePlayer.text.Substring(0, namePlayer.text.Length - 1);
        }else if(letter != "DELETE"){
                if(namePlayer.text.Length < 10){
                namePlayer.text =  namePlayer.text + letter;
            } else {
            maxCharacters.enabled = true;
        } 
        }

    }
}
