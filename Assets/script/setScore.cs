using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class setScore : MonoBehaviour
{
    
   
    public GameObject scoreTextPrefab;
    public GameObject parent;
    private GameObject scoreText;
    int count=0;
    dataBase dataBase;
    GameInfo gameInfo1;
     
     
    // Start is called before the first frame update
     void Start()
    {
        
         dataBase = GameObject.FindObjectOfType<dataBase>();

         List<int> idGame = dataBase.GetTopGames(dataBase.GetGameCount());
         
        
       
         
         
        while (count<dataBase.GetGameCount())
        {

            gameInfo1 = dataBase.GetGameInfo(idGame[count]);
                // Instancie une copie de l'objet en entrée
            GameObject copiedObject = Instantiate(scoreTextPrefab, scoreTextPrefab.transform.parent);

            // Déplace la nouvelle instance vers le bas de 70 unités
            Vector3 newPosition = copiedObject.transform.position;
            newPosition.y -= 70f*(count+1);
            copiedObject.transform.position = newPosition;
            count++;

            TextMeshProUGUI[] childrenTextMeshPros = copiedObject.GetComponentsInChildren<TextMeshProUGUI>();

            for (int i = 0; i < childrenTextMeshPros.Length; i++)
            {
                  TextMeshProUGUI textMeshPro = childrenTextMeshPros[i];
                if(i==0){
                    textMeshPro.text = dataBase.GetPlayerPseudo(gameInfo1.idPlayer1);

                } else if(i==1){
                    textMeshPro.text = gameInfo1.score1.ToString();
                    

                } else if(i==2){
                    textMeshPro.text = dataBase.GetPlayerPseudo(gameInfo1.idPlayer2);
                    

                } else if(i==3){
                    textMeshPro.text = gameInfo1.score2.ToString();

                } else if(i==4){
                    textMeshPro.text = gameInfo1.rank.ToString();

                } 
              
                
            
            }

       


        }

        if(dataBase.GetGameCount() == 0){
            scoreTextPrefab.SetActive(true);

        } else {
            scoreTextPrefab.SetActive(false);

        }


        
       
    
}
    

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("newPosition : x  =" + scoreText.transform.position.x + " y = " + scoreText.transform.position.y  + " z = " + scoreText.transform.position.z);
    }

    
}






    

