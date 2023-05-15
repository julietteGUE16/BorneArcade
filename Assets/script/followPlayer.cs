using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



/*
Ce script permet que le nom du joueur suive le joueur
*/


public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public new TextMeshPro name;
    
    void Start()
    {
        
        string test = player.GetComponent<Player>().playerName;
       
        name.text = test;
        
    }

  
    void Update()
    {
        transform.position = player.transform.position + new Vector3(0, 1.1f, 0);
    }
}
