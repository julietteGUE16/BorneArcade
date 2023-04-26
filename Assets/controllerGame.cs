using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using System.Management;


public class controllerGame : MonoBehaviour
{
    private InputDevice stickController1;
    private InputDevice stickController2;

    private Joystick j1;
    private Joystick j2;


    // Start is called before the first frame update
    void Start()
    {

        // Query all USB devices using WMI
        ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_USBControllerDevice");
        ManagementObjectCollection collection = searcher.Get();

        // Iterate through each USB device and print its details
        foreach (ManagementObject device in collection)
        {
            // Retrieve the device's path and name
            string devicePath = (string)device["Dependent"];
            string deviceName = (string)device["Antecedent"];

            // Parse the device's ID from its path
            string deviceId = devicePath.Substring(devicePath.IndexOf("DeviceID") + 10).Replace("\\", "").Replace("\"", "");

            // Print the device's ID and name
            Debug.Log("Device ID: " + deviceId);
            Debug.Log("Device Name: " + deviceName);
        }

        var devices = InputSystem.devices;

        this.j1 = devices[4] as Joystick;
        this.j2 = devices[5] as Joystick;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (j1 != null){
            Debug.Log(j1.stick.x);
            Debug.Log(j1.stick.y);
        } else {
            //Debug.Log("j1 null");
        }
        
    }
}
