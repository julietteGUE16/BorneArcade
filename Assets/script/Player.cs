using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;





public class Player : MonoBehaviour
{

   public TextMeshProUGUI finish;
   public TextMeshProUGUI winner;
   public TextMeshProUGUI looser;
   public TextMeshProUGUI namePlayerWinner;
   public TextMeshProUGUI namePlayerLooser;
   public Image font;
   public GameObject spriteRendererLooseLife;
    
   
    public weapon weapon;
    private Rigidbody2D rb;
    menuController menuController;
    public int playerNumber;
    
    private Vector2 smoothDampVelocity;
    public float smoothDampTime = 0.1f;
    Vector2 stickPosition;
    
    public bool isStartLeft;
    public bool isStartFinish=false;
    public Vector2 movement = Vector2.zero;
    public Vector2 lastMovement = Vector2.zero;

    public Image life1;
    public Image life2;
    public Image life3;
    public Image life4;
    public Image life5;

    public Color lifeLose;

    public bool isEnd = false;

    


    public gameSet gameSet;
    public string playerName="";
    public float speed=10f;
    public float rotationSpeed = 5f;
    public int life=5;
    //choisi dans les paramètre et si il est max grosses balles mais grand pause entre les tires
    public float delayFire=0.2f;
   
    public float powerFire=1f;
    //
    public float speedFire=10f;

    public float score = 0f;

    EventSystem eventSystem;

    public bool canFire = true;

    startRound startRound;

   

    Joystick j2;
    Gamepad g2;
    // Start is called before the first frame update
    void Start()
    {
        gameSet = GameObject.FindObjectOfType<gameSet>();
        spriteRendererLooseLife.GetComponent<SpriteRenderer>().enabled = false;
        startRound = GameObject.FindObjectOfType<startRound>();
            menuController =GameObject.FindObjectOfType<menuController>();


        speed = speed*10;
        rotationSpeed = rotationSpeed*600;
        delayFire = delayFire/10;
        powerFire = powerFire/2;


        eventSystem = EventSystem.current;
         font.enabled = false;
        finish.enabled = false;
        winner.enabled = false;
        looser.enabled = false;
        namePlayerWinner.enabled = false;
        namePlayerLooser.enabled = false;
        rb =GetComponent<Rigidbody2D>();
        Time.timeScale = 0.25f;
        var devices = InputSystem.devices;
      
        //Debug.Log(" device 1 :  "+devices[playerNumber].name);
        //Debug.Log("test = "+devices[playerNumber].name.Contains("XInputControllerWindows"));
        if(playerNumber == 0){
            Debug.Log(" player j1"+gameSet.j1 );
            if(gameSet.j1 != null){
                j2 = gameSet.j1;
            }else if(gameSet.g1 != null){
                g2 = gameSet.g1;
            }
        }else if(playerNumber == 1){
            if(gameSet.j2 != null){
                j2 = gameSet.j2;
            }else if(gameSet.g2 != null){
                g2 = gameSet.g2;
            }
        }
             
           

      
        //Debug.Log(" device 4 :  "+devices[0].name);
        //Debug.Log(" device 5 :  "+devices[1].name);
      

      
             
    }
    // Update is called once per frame

 

    void Update()
    {

        if(life == 4){
            life5.color = lifeLose;
        }else if(life == 3){
            life4.color = lifeLose;
        }else if(life == 2){
            life3.color = lifeLose;
        }else if(life == 1){
            life2.color = lifeLose;
        }else if(life == 0){
            if(!isEnd){
                isEnd = true;
                life1.color = lifeLose;
                startRound.isEnd = true;
                StartCoroutine(EndGame());
            }
         
              
        }


          if(j2 != null){
          


         stickPosition = j2.stick.ReadValue();
    
        rb.velocity = stickPosition * speed;

       /* if(j2.trigger.value == 1){

            //playerMouvement
            Debug.Log("tir");
           Debug.Log("button : "+ eventSystem.currentSelectedGameObject.name);//.onClick.Invoke();
        }*/
           
            
        }else if(g2 != null){
           
         stickPosition = g2.leftStick.ReadValue();

        //rb.velocity = stickPosition * speed;

        Vector2 targetVelocity = stickPosition * speed;
        rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref smoothDampVelocity, smoothDampTime);
    
        movement = stickPosition;
        if(movement != Vector2.zero){
            lastMovement = movement;
        }
        if(g2.buttonSouth.wasPressedThisFrame){

            //playerMouvement
            if(canFire){
            Debug.Log("tir");
            
            weapon.playerMovement = lastMovement.normalized;
            weapon.EffectuerTir(powerFire);
            StartCoroutine(FireRate());
            }
        }
        
        
        }
        
        else {
         //Debug.Log("j2 et g2 null");
        }

          Vector2 movementDirection = stickPosition.normalized;
           

    if (movementDirection != Vector2.zero)
{
    float angle = Mathf.Atan2(movementDirection.y, movementDirection.x) * Mathf.Rad2Deg;
    
    // Ajuster l'angle de rotation en fonction de la direction
    if(!isStartFinish){
        isStartFinish = true;
    if (movementDirection.x < 0f)
    {
        if(isStartLeft){
        angle += 180f; // Si la direction est vers la gauche, ajouter 180 degrés
        }
    }
    }
    
          Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    
}
        

       

      
        
    }

    public IEnumerator EndGame()
    {
        //Debug.Log("endGame");
       
        font.enabled = true;
        winner.enabled = true;
        looser.enabled = true;
        //TODO : calcul du score
        finish.enabled = true;
        namePlayerWinner.enabled = true;
        namePlayerLooser.enabled = true;
        yield return new WaitForSeconds(1.6f);
        
        menuController.loadAllScene("endGame");   // Attendre 5 secondes
        
       
    }

    public IEnumerator FireRate()
    {
        canFire = false;
        yield return new WaitForSeconds(delayFire);
        canFire = true;
    }


    public int getScore(){
        return 0;

    }


    public IEnumerator waitLooseLife(){
        Debug.Log("waitLooseLife");
        yield return new WaitForSeconds(0.03f);
         spriteRendererLooseLife.GetComponent<SpriteRenderer>().enabled = false;

    }

     

     
    
     
}


