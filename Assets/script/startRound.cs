using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class startRound : MonoBehaviour
{
    public TextMeshProUGUI text;
    public TextMeshProUGUI player1;
    public TextMeshProUGUI player2;
    gameSet gameSet;

    public TextMeshProUGUI finish;
   public TextMeshProUGUI winner;
   public TextMeshProUGUI looser;
   public TextMeshProUGUI namePlayerWinner;
   public TextMeshProUGUI namePlayerLooser;
   public TextMeshProUGUI namePlayerWinnerScore;
   public TextMeshProUGUI namePlayerLooserScore;
   public Image font;

    
    private bool isRunning = false;
    private float startTime;
    private float elapsedTime;

    public GameObject player1Object;
    public GameObject player2Object;

    public bool isEnd = false;

    dataBase dataBase;

    
    // Start is called before the first frame update
    void Start()
    {

        dataBase = GameObject.FindObjectOfType<dataBase>();
        font.enabled = false;
        finish.enabled = false;
        winner.enabled = false;
        looser.enabled = false;
        namePlayerWinner.enabled = false;
        namePlayerLooser.enabled = false;
        namePlayerWinnerScore.enabled = false;
        namePlayerLooserScore.enabled = false;
         isRunning = true;
        startTime = Time.time;
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
            gameSet.scorePlayer1 = (int)player1Object.GetComponent<Player>().getScore();
            gameSet.scorePlayer2 = (int)player2Object.GetComponent<Player>().getScore();

            font.enabled = true;
            winner.enabled = true;
            looser.enabled = true;
            finish.enabled = true;

            if(gameSet.scorePlayer1 > gameSet.scorePlayer2){
                namePlayerWinner.text = gameSet.namePlayer1;
                namePlayerLooser.text = gameSet.namePlayer2;
                namePlayerWinnerScore.text = gameSet.scorePlayer1.ToString();
                namePlayerLooserScore.text = gameSet.scorePlayer2.ToString();
            }else{
                namePlayerWinner.text = gameSet.namePlayer2;
                namePlayerLooser.text = gameSet.namePlayer1;
                namePlayerWinnerScore.text = gameSet.scorePlayer2.ToString();
                namePlayerLooserScore.text = gameSet.scorePlayer1.ToString();
            }



            namePlayerWinner.enabled = true;
            namePlayerLooser.enabled = true;
            namePlayerWinnerScore.enabled = true;
            namePlayerLooserScore.enabled = true;

            int rank = dataBase.CalculateGameRank(gameSet.scorePlayer1,gameSet.scorePlayer2);
            Debug.Log("rank startRound : " + rank);
            dataBase.AddGame(gameSet.idPlayer1,gameSet.idPlayer2,gameSet.scorePlayer1,gameSet.scorePlayer2, rank);
            dataBase.UpdateGameRankInDatabase(rank, gameSet.idPartie);
            gameSet.rankGame = rank;

        }

        if (isRunning)
        {
            elapsedTime = Time.time - startTime;
        
        }
    }

    IEnumerator StartRound(){
        
        yield return new WaitForSeconds(0.5f);
        text.enabled = false; 
     
    }

    public float StopAndGetChronometer()
    {
        isRunning = false;
        elapsedTime = Time.time - startTime;
        return elapsedTime;
    }
}
