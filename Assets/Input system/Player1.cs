using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;


public class Player1 : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;

    private InputDevice stickController1;
    private InputDevice stickController2;

    // void Update()
    // {
    //     float joy0X = Input.GetAxis("Joy0X");
    //     float joy0Y = Input.GetAxis("Joy0Y");

    // // Récupérer les entrées du deuxième joystick
    // float joy1X = Input.GetAxis("Joy1X");
    // float joy1Y = Input.GetAxis("Joy1Y");

    //     for (int i = 0; i < 2; i++)
    //     {
    //         Debug.Log(Input.GetAxis("Joy" + i + "X"));
    //         Debug.Log(Input.GetAxis("Joy" + i + "Y"));
    //         if (Mathf.Abs(Input.GetAxis("Joy" + i + "X")) > 0.2 ||
    //             Mathf.Abs(Input.GetAxis("Joy" + i + "Y")) > 0.2)
    //         {
    //             Debug.Log(Input.GetJoystickNames()[i] + " is moved");
    //         }
    //     }
    // }

    void Start()
    {
        rb =GetComponent<Rigidbody2D>();
        Time.timeScale = 0.25f;

        var devices = InputSystem.devices;
        Debug.Log(devices[4].name);
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

    
    private void OnMove(InputValue input){
        // var joystick = Joystick.current;
        // Debug.Log(joystick);
         Vector2 inputVec = input.Get<Vector2>();
         Vector2 vel = rb.velocity;
         Vector2 pos = transform.position;
         rb.velocity = inputVec * speed;
         
    //     if (deviceId == "DragonRise Inc.   Generic   USB  Joystick  ")
    // {
    //     Debug.Log("ça marche ;)");
    // }
        //Joystick joystick = InputSystem.GetDevice<Joystick>(input.source.deviceId);
        
        // if (joystick != null && joystick.deviceId == "DragonRise Inc.   Generic   USB  Joystick  ")
        // {
        //     Debug.Log("P2");
        //     Vector2 inputVec = input.Get<Vector2>();
        //      Vector2 vel = rb.velocity;
        //      Vector2 pos = transform.position;
        //      rb.velocity = inputVec * speed;
        // }
    }
}
