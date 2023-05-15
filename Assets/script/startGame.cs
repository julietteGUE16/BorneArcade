using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Ce script permet de lancer le menu du jeu
*/


public class StartGame : MonoBehaviour
{
    MenuController menuController;
    // Start is called before the first frame update
    void Start()
    {
        menuController = GameObject.FindObjectOfType<MenuController>();
        menuController.loadAllScene("startMenu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
