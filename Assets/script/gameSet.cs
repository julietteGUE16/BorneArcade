using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameSet : MonoBehaviour
{
    
    

    
    int idPartie=-1;
    int scorePlayer1=0;
    int scorePlayer2=0;

    int idPlayer1=-1;
    int idPlayer2=-1;
    string namePlayer1="";
    string namePlayer2="";
     
    public float speedPlayer1=0.1f;
    public float speedRotationPlayer1=0.2f;
    public float powerFire1=0.2f;
    public float delayFire1=0.2f;
    

    public float speedPlayer2=0.1f;
    public float speedRotationPlayer2=0.2f;
    public float powerFire2=0.2f;
    public float delayFire2=0.2f;
 
    // Start is called before the first frame update
    private void Awake()
    {
        // Empêcher la destruction de l'objet lors du changement de scène
        DontDestroyOnLoad(gameObject);
    }
        
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
