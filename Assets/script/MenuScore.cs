using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Ce script controler le menu score and y retrouve la fonction pour supprimer les parties
*/


public class MenuScore : MonoBehaviour
{
    DataBase database;
    MenuController menuController;
    // Start is called before the first frame update
    void Start()
    {
        database = GameObject.FindObjectOfType<DataBase>(); 
        menuController = GameObject.FindObjectOfType<MenuController>();
     
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
