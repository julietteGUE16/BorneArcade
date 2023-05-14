using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class SetScoreEnd : MonoBehaviour
{
    public TextMeshProUGUI CurrentGamenamePlayer1;
    public TextMeshProUGUI CurrentGamenamePlayer2;
    public TextMeshProUGUI CurrentGameScorePlayer1;
    public TextMeshProUGUI CurrentGameScorePlayer2;
    public TextMeshProUGUI CurrentGameRank;

   /* public TextMeshProUGUI Rank1NamePlayer1;
    public TextMeshProUGUI Rank1NamePlayer2;
    public TextMeshProUGUI Rank1ScorePlayer1;
    public TextMeshProUGUI Rank1ScorePlayer2;

    public TextMeshProUGUI Rank2NamePlayer1;
    public TextMeshProUGUI Rank2NamePlayer2;
    public TextMeshProUGUI Rank2ScorePlayer1;
    public TextMeshProUGUI Rank2ScorePlayer2;

    public TextMeshProUGUI Rank3NamePlayer1;
    public TextMeshProUGUI Rank3NamePlayer2;
    public TextMeshProUGUI Rank3ScorePlayer1;
    public TextMeshProUGUI Rank3ScorePlayer2;

    public TextMeshProUGUI Rank4NamePlayer1;
    public TextMeshProUGUI Rank4NamePlayer2;
    public TextMeshProUGUI Rank4ScorePlayer1;
    public TextMeshProUGUI Rank4ScorePlayer2;

    public TextMeshProUGUI Rank5NamePlayer1;
    public TextMeshProUGUI Rank5NamePlayer2;
    public TextMeshProUGUI Rank5ScorePlayer1;
    public TextMeshProUGUI Rank5ScorePlayer2;*/

    GameInfo gameInfo1;



    public Image BestPartyObjectRank1IsCurrentRank;
    public Image BestPartyObjectRank2IsCurrentRank;
    public Image BestPartyObjectRank3IsCurrentRank;
    public Image BestPartyObjectRank4IsCurrentRank;
    public Image BestPartyObjectRank5IsCurrentRank;
  
    

    public GameObject BestPartyObject1;
    public GameObject BestPartyObject2;
    public GameObject BestPartyObject3;
    public GameObject BestPartyObject4;
    public GameObject BestPartyObject5;

    
   

    dataBase dataBase;
    gameSet gameSet;
    // Start is called before the first frame update
    void Start()
    {
        

        
        BestPartyObjectRank1IsCurrentRank.enabled = false;
        BestPartyObjectRank2IsCurrentRank.enabled = false;
        BestPartyObjectRank3IsCurrentRank.enabled = false;
        BestPartyObjectRank4IsCurrentRank.enabled = false;
        BestPartyObjectRank5IsCurrentRank.enabled = false;
        dataBase = GameObject.FindObjectOfType<dataBase>();
        gameSet = GameObject.FindObjectOfType<gameSet>();
        CurrentGamenamePlayer1.text = gameSet.namePlayer1;
        CurrentGameScorePlayer1.text = gameSet.scorePlayer1.ToString();
        CurrentGamenamePlayer2.text = gameSet.namePlayer2;
        CurrentGameScorePlayer2.text = gameSet.scorePlayer2.ToString();
        CurrentGameRank.text = gameSet.rankGame.ToString();

        
        List<GameObject> bestParty = new List<GameObject>();
        bestParty.Add(BestPartyObject1);
        bestParty.Add(BestPartyObject2);
        bestParty.Add(BestPartyObject3);
        bestParty.Add(BestPartyObject4);
        bestParty.Add(BestPartyObject5);

        List<int> idTopgame = dataBase.GetTopGames(5);

        for(int j=0; j<idTopgame.Count; j++)
        {
           
            gameInfo1 = dataBase.GetGameInfo(idTopgame[j]);
            
        
            TextMeshProUGUI[] childrenTextMeshPros = bestParty[j].GetComponentsInChildren<TextMeshProUGUI>();


        
            for (int i = 0; i < childrenTextMeshPros.Length; i++)
            {
                  TextMeshProUGUI textMeshPro = childrenTextMeshPros[i];
                if(i==0){
                    textMeshPro.text = dataBase.GetPlayerPseudo(gameInfo1.idPlayer1);

                } else if(i==1){
                    textMeshPro.text = dataBase.GetPlayerPseudo(gameInfo1.idPlayer2);

                } else if(i==2){
                    textMeshPro.text = gameInfo1.score1.ToString();

                } else if(i==3){
                    textMeshPro.text = gameInfo1.score2.ToString();

                } 
              
                
            
            }
        }
        

        if (gameSet.rankGame == 1)
        {
            BestPartyObjectRank1IsCurrentRank.enabled = true;
        }else if (gameSet.rankGame == 2)
        {
            BestPartyObjectRank2IsCurrentRank.enabled = true;
        }else if (gameSet.rankGame == 3)
        {
            BestPartyObjectRank3IsCurrentRank.enabled = true;
        }else if (gameSet.rankGame == 4)
        {
            BestPartyObjectRank4IsCurrentRank.enabled = true;
        }else if (gameSet.rankGame == 5)
        {
            BestPartyObjectRank5IsCurrentRank.enabled = true;
        }
       
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
