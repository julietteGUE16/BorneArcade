using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;


public class Player2 : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;

    private InputDevice stickController1;
    private InputDevice stickController2;

    private Joystick j1;
    private Joystick j2;

    void Update(){
        if (j1 != null){
             Debug.Log(j1.stick.x);
        Debug.Log(j1.stick.y);
        }
        // rb.velocity = j1.stick * speed;
    }


    void Start()
    {
        rb =GetComponent<Rigidbody2D>();
        Time.timeScale = 0.25f;

        var devices = InputSystem.devices;

        this.j1 = devices[4] as Joystick;
        this.j2 = devices[5] as Joystick;

        Debug.Log(devices[4].GetType().ToString());
        Debug.Log(devices[5].name);
        foreach (var device in devices)
        {
            if ((device.name == "DragonRise Inc.   Generic   USB  Joystick  ") || (device.name == "DragonRise Inc.   Generic   USB  Joystick  1"))
            {
                Debug.Log("ok");
                // Obtention de la référence à la manette en utilisant son identifiant unique
                if (stickController1 == null)
                {
                    stickController1 = InputSystem.GetDeviceById(device.deviceId);
                    Debug.Log("stickController1");
                }
                else if (stickController2 == null)
                {
                    stickController2 = InputSystem.GetDeviceById(device.deviceId);
                    Debug.Log("stickController2");
                }
            }
        }
    }

    
    // private void OnMove(InputValue input){
    //      Debug.Log("P2");
    //      Vector2 inputVec = input.Get<Vector2>();
    //      Vector2 vel = rb.velocity;
    //      Vector2 pos = transform.position;
    //      rb.velocity = inputVec * speed;
    // }
}

