using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class SetScoreEnd : MonoBehaviour
{
    public GameObject PartyObject;
    public GameObject BestPartyObject1;
    public GameObject BestPartyObject2;
    public GameObject BestPartyObject3;
    public GameObject BestPartyObject4;
    public GameObject BestPartyObject5;
    public List<GameObject> partyObjects = new List<GameObject>();
    dataBase dataBase;
    gameSet gameSet;
    // Start is called before the first frame update
    void Start()
    {
      
        dataBase = GameObject.FindObjectOfType<dataBase>();
        gameSet = GameObject.FindObjectOfType<gameSet>();
        partyObjects.Add(PartyObject);
        partyObjects.Add(BestPartyObject1);
        partyObjects.Add(BestPartyObject2);
        partyObjects.Add(BestPartyObject3);
        partyObjects.Add(BestPartyObject4);
        partyObjects.Add(BestPartyObject5);
        int count = dataBase.GetGameCount() +1;
        Debug.Log("count : " + count);
        if(count > 5){
            count = 5;
        }
        Debug.Log("party count = "+partyObjects.Count);
        for(int i = 0; i < count; i++){
            TextMeshPro[] childrenTextMeshPros=  new TextMeshPro[0];
            for (int j = 0; j < partyObjects.Count; j++)
            {
                childrenTextMeshPros = partyObjects[j].GetComponentsInChildren<TextMeshPro>();
            }
            

                if (i == 0)
                {
                    childrenTextMeshPros[0].text = gameSet.namePlayer1;
                    childrenTextMeshPros[1].text = gameSet.scorePlayer1.ToString();
                    childrenTextMeshPros[2].text = gameSet.namePlayer2;
                    childrenTextMeshPros[3].text = gameSet.scorePlayer2.ToString();
                    childrenTextMeshPros[4].text = gameSet.rankGame.ToString();
                }
                else
                {
                   //TODO : autres scores
                }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
