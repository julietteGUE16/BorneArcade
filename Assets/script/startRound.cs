using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class startRound : MonoBehaviour
{
    public TextMeshProUGUI text;
    public TextMeshProUGUI player1;
    public TextMeshProUGUI player2;
    gameSet gameSet;

    public GameObject player1Object;
    public GameObject player2Object;

    public bool isEnd = false;
    // Start is called before the first frame update
    void Start()
    {
        gameSet = GameObject.FindObjectOfType<gameSet>();
        
        player1.text = gameSet.namePlayer1;
        player2.text = gameSet.namePlayer2;
        text.enabled   = true;
        StartCoroutine(StartRound()); 

        player1Object.GetComponent<Player>().playerName = gameSet.namePlayer1;
        player2Object.GetComponent<Player>().playerName = gameSet.namePlayer2;

        player1Object.GetComponent<Player>().rotationSpeed = gameSet.speedRotationPlayer1;
        player2Object.GetComponent<Player>().rotationSpeed = gameSet.speedRotationPlayer2;

        player1Object.GetComponent<Player>().speed = gameSet.speedPlayer1;
        player2Object.GetComponent<Player>().speed = gameSet.speedPlayer2;


        player1Object.GetComponent<Player>().delayFire = gameSet.delayFire1;
        player2Object.GetComponent<Player>().delayFire = gameSet.delayFire2;

        player1Object.GetComponent<Player>().powerFire = gameSet.powerFire1;
        player2Object.GetComponent<Player>().powerFire = gameSet.powerFire2;

      

    }


    
    // Update is called once per frame
    void Update()
    {

        if(isEnd){
            isEnd = false;
            gameSet.scorePlayer1 = player1Object.GetComponent<Player>().getScore();
            gameSet.scorePlayer2 = player2Object.GetComponent<Player>().getScore();


            //TODO ajouter game a la bdd
        }
        
    }

    IEnumerator StartRound(){
        
        yield return new WaitForSeconds(0.5f);
        text.enabled   = false; 
     
    }
}
