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
