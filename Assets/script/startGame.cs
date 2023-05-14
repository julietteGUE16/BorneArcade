using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startGame : MonoBehaviour
{
    menuController menuController;
    // Start is called before the first frame update
    void Start()
    {
        menuController = GameObject.FindObjectOfType<menuController>();
        menuController.loadAllScene("startMenu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
