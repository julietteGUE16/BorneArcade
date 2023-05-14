using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/*
 * Classe permettant de récupérer les périphériques envoyés par le script js mis dans le html 
 */

public class DeviceHandler : MonoBehaviour
{


    gameSet gameSet;

    void Start (){

    DontDestroyOnLoad(gameObject);
    gameSet = GameObject.Find("gameSet").GetComponent<gameSet>();
    }
 


    // Méthode pour recevoir les informations sur les périphériques
    public void OnDevicesDetected(DeviceData[] devices)
    {
        foreach (DeviceData device in devices)
        {
           /* Debug.Log("Nom du périphérique : " + device.deviceName);
            Debug.Log("ID du périphérique : " + device.deviceId);
            Debug.Log("Type du périphérique : " + device.deviceType);*/

            //gameSet.test1.text += "\n"+" device "+device.deviceId+" :  "+device.deviceName;


           
        }

    }
}

[System.Serializable]
public struct DeviceData
{
    public string deviceName;
    public string deviceId;
    public string deviceType;
}