using UnityEngine;
using UnityEngine.UI;

/*
Ce script permet de controler le panel
*/

public class PanelOpener : MonoBehaviour
{
    public GameObject panel;
 


    public void OpenPanel()
    {
       
        panel.SetActive(true);
    }

    public void ClosePanel()
    {
       
        panel.SetActive(false);
    }

   
}