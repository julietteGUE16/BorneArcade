using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScore : MonoBehaviour
{
    dataBase database;
    menuController menuController;
    // Start is called before the first frame update
    void Start()
    {
        database = GameObject.FindObjectOfType<dataBase>(); 
        menuController = GameObject.FindObjectOfType<menuController>();
        //todo : get score from database
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeleteData(){
        menuController.loadAllScene("scores");
        database.DeleteAllGames();
        
    }
}
