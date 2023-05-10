using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class menuStart : MonoBehaviour
{
    public Button joinPlayer1;
    public Button joinPlayer2;
    public TextMeshProUGUI joinPlayer1Text;
    public TextMeshProUGUI joinPlayer2Text;
    public TextMeshProUGUI player1Text;
    public TextMeshProUGUI player2Text;
    
    // Start is called before the first frame update
    void Start()
    {
        //joinPlayer1 = GameObject.Find("joinPlayer1").GetComponent<Button>();
        //joinPlayer1Text = 
        
    }

    // Update is called once per frame
    void Update()
    {
/*if(joinPlayer1.IsInteractable() && EventSystem.current != null && EventSystem.current.currentSelectedGameObject == joinPlayer1.gameObject){              player1Text.color = Color.red;
            joinPlayer1Text.color = Color.red;
        } else {
            player1Text.color = Color.white;
            joinPlayer1Text.color = Color.white;
        }*/
    }

    public void setPlayer1(){
        
        
    }
}
