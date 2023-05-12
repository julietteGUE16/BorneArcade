using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class startRound : MonoBehaviour
{
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text.enabled   = true;
     StartCoroutine(StartRound());   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartRound(){
        
        yield return new WaitForSeconds(0.5f);
        text.enabled   = false; 
     
    }
}
