using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class followPlayer : MonoBehaviour
{
    public GameObject player;

 
  
   
    
    public new TextMeshPro name;
    // Start is called before the first frame update
    void Start()
    {
        
        string test = player.GetComponent<Player>().playerName;
       
        name.text = test;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + new Vector3(0, 1.1f, 0);
    }
}
