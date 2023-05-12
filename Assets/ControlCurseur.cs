using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControlCurseur : MonoBehaviour
{
    public GameObject cursorSpeedPlayer;
    public GameObject CursorRotationSpeedPlayer;
    public GameObject CursorPowerFirePlayer;
    public GameObject CursorDelayFirePlayer;

    public TextMeshProUGUI textSpeedPlayer;
    public TextMeshProUGUI textRotationSpeedPlayer;
    public TextMeshProUGUI textPowerFirePlayer;
    public TextMeshProUGUI textDelayFirePlayer;

    gameSet gameSet;
    getData getData;
    public bool panelOpen = true;
    public bool firstTime = true;
   
    // Start is called before the first frame update
    void Start()
    {
       
        getData = GameObject.FindObjectOfType<getData>();
        gameSet = GameObject.FindObjectOfType<gameSet>();

        
    }

    // Update is called once per frame
    void Update()
    {
       
        if(panelOpen){
            if(firstTime){
                firstTime = false;
            if(!getData.isPlayer2){

            cursorSpeedPlayer.GetComponent<Slider>().value = gameSet.speedPlayer1;
            CursorRotationSpeedPlayer.GetComponent<Slider>().value = gameSet.speedRotationPlayer1;
            CursorPowerFirePlayer.GetComponent<Slider>().value = gameSet.powerFire1;
            CursorDelayFirePlayer.GetComponent<Slider>().value = gameSet.delayFire1;
            textSpeedPlayer.text = gameSet.speedPlayer1.ToString();
            textRotationSpeedPlayer.text = gameSet.speedRotationPlayer1.ToString();
            textPowerFirePlayer.text = gameSet.powerFire1.ToString();
            textDelayFirePlayer.text = gameSet.delayFire1.ToString();
        }
        else{
            cursorSpeedPlayer.GetComponent<Slider>().value = gameSet.speedPlayer2;
            CursorRotationSpeedPlayer.GetComponent<Slider>().value = gameSet.speedRotationPlayer2;
            CursorPowerFirePlayer.GetComponent<Slider>().value = gameSet.powerFire2;
            CursorDelayFirePlayer.GetComponent<Slider>().value = gameSet.delayFire2;
            textSpeedPlayer.text = gameSet.speedPlayer2.ToString();
            textRotationSpeedPlayer.text = gameSet.speedRotationPlayer2.ToString();
            textPowerFirePlayer.text = gameSet.powerFire2.ToString();
            textDelayFirePlayer.text = gameSet.delayFire2.ToString();
        }
            
        } else {
            textSpeedPlayer.text = cursorSpeedPlayer.GetComponent<Slider>().value.ToString();
            textRotationSpeedPlayer.text = CursorRotationSpeedPlayer.GetComponent<Slider>().value.ToString();
            textPowerFirePlayer.text = CursorPowerFirePlayer.GetComponent<Slider>().value.ToString();
            textDelayFirePlayer.text = CursorDelayFirePlayer.GetComponent<Slider>().value.ToString();
            if(!getData.isPlayer2){
            gameSet.speedPlayer1= cursorSpeedPlayer.GetComponent<Slider>().value;
            gameSet.speedRotationPlayer1= CursorRotationSpeedPlayer.GetComponent<Slider>().value;
            gameSet.powerFire1= CursorPowerFirePlayer.GetComponent<Slider>().value;
            gameSet.delayFire1= CursorDelayFirePlayer.GetComponent<Slider>().value;
            }
            else{   
            gameSet.speedPlayer2= cursorSpeedPlayer.GetComponent<Slider>().value;
            gameSet.speedRotationPlayer2= CursorRotationSpeedPlayer.GetComponent<Slider>().value;
            gameSet.powerFire2= CursorPowerFirePlayer.GetComponent<Slider>().value;
            gameSet.delayFire2= CursorDelayFirePlayer.GetComponent<Slider>().value;
            }            
        }
        }

        
    }

    void ResetCursor(){
        cursorSpeedPlayer.GetComponent<Slider>().value = 0;
        CursorRotationSpeedPlayer.GetComponent<Slider>().value = 0;
        CursorPowerFirePlayer.GetComponent<Slider>().value = 0;
        CursorDelayFirePlayer.GetComponent<Slider>().value = 0;
    }
}
