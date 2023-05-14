using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setScore : MonoBehaviour
{
    
    public GameObject scoreTextPrefab;
    public GameObject parent;
    //private GameObject scoreText;
    float positionDépartY = 130f;
     int count=1;
    // Start is called before the first frame update
    void Start()
    {
       
        //scoreText = Instantiate(scoreTextPrefab, spawn.position, spawn.rotation);
        while (count > 0)
        {
            CreateScoreText();
            count--;
           
            positionDépartY -= 72f;
        }
      
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("newPosition : x  =" + scoreText.transform.position.x + " y = " + scoreText.transform.position.y  + " z = " + scoreText.transform.position.z);
    }

    void CreateScoreText()
    {
        GameObject scoreText = Instantiate(scoreTextPrefab, parent.transform);
    
        float posY = positionDépartY;
        Vector3 currentPosition = scoreText.transform.position;
            currentPosition.x = -229f;
            currentPosition.y = posY;
            currentPosition.z = 0f;

            scoreText.transform.position = currentPosition;


       
        
    }
}
